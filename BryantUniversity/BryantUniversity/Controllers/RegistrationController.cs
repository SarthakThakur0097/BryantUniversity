using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using BryantUniversity.Security;
using BryantUniversity.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    [Authorize(Roles = "4")]
    public class RegistrationController : Controller
    {
        private Context context;

        public CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }

        public RegistrationController()
        {
            context = new Context();
        }

        [HttpGet]
        public ActionResult Index()
        {
            using (context)
            {
                User currUser = new UserRepo(context).GetByEmail(User.Identity.Name);
                IList<Registration> registration = new RegistrationRepo(context).GetRegistrationByUserId(currUser.Id);
                return View(registration);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            using (context) {
                IList<CourseSection> courseSections = new CourseSectionRepo(context).GetCourseSectionsByCourseId(id);
                return View(courseSections);
            }
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            MajorPreRequisitesRepo mprRepo;
            CourseSectionRepo csRepo;
            RegistrationRepo rRepo;
            StudentHoldRepo hRepo;
            CourseSection toAdd;
            GradesRepo gRepo;
            IList<StudentHold> studentHolds = new List<StudentHold>();
            RegistrationViewModel viewModel = new RegistrationViewModel();

            using (context)
            {
                csRepo = new CourseSectionRepo(context);
                rRepo = new RegistrationRepo(context);
                hRepo = new StudentHoldRepo(context);
                mprRepo = new MajorPreRequisitesRepo(context);
                gRepo = new GradesRepo(context);

                toAdd = csRepo.GetCourseSectionById(id);
                CourseSection roomCheck = csRepo.GetCourseSectionById(id);
                IList<Registration> allRegistrationsforSection = rRepo.GetRegistrationsByCourseSectionId(id);
                IList<MajorPreRequisite> allReqs = mprRepo.GetAllMajorPrequisitesByCourse(toAdd.Course.Id);
                IList<Grade> allTakenCourses = gRepo.GetAllGradesByUserId(CustomUser.User.Id);

                if(toAdd.SemesterPeriodId != 1)
                {
                    viewModel.PreviousSemesterConflict = true;
                    return View(viewModel);
                }
                else if (allReqs.Count > 0 && allTakenCourses.Count == 0)
                {
                    viewModel.NotTakenPreReqConflict = true;

                    return View(viewModel);
                }
                else if(allRegistrationsforSection.Count >= roomCheck.Room.RoomCapacity)
                {
                    viewModel.isOverRoomCapacity = true;

                    return View(viewModel);
                }
                foreach (var req in allReqs)
                {
                    foreach (var takenCourse in allTakenCourses)
                    {

                        if (takenCourse.Registration.CourseSection.CourseId != req.CourseId)
                        {
                            viewModel.NotTakenPreReqConflict = true;
                            return View(viewModel);
                        }
                    }
                }

                studentHolds = hRepo.GetAllStudentHoldsByUserId(CustomUser.User.Id);
               
                if (studentHolds.Count>0)
                {
                    viewModel.HasHold = true;

                    return View(viewModel);
                }
                SemesterPeriod toAddPeriod = toAdd.SemesterPeriod;
                
                IList<Registration> registrations = rRepo.GetRegistrationByUserAndCourseSection(CustomUser.User.Id, id);
                IList<CourseSection> registeredCourseSections = new List<CourseSection>();

                foreach(Registration registration in registrations)
                {
                    if(registration.CourseSectionId == id)
                    {
                        viewModel.SameClassConflict = true;
                        return View(viewModel);
                    } 
                    else if (registration.CourseSection.SemesterPeriod == toAddPeriod)
                    {
                        viewModel.TimeConflict = true;
                        return View(viewModel);
                    }
                }
        
                Registration userCourseSection = new Registration(CustomUser.User.Id, toAdd.Id);
                rRepo.Insert(userCourseSection);
            }
            return RedirectToAction("Index", "Schedule");
        }
    }
}