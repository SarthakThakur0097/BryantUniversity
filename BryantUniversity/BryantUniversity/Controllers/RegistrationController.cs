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
            CourseSectionRepo csRepo;
            RegistrationRepo rRepo;
            StudentHoldRepo hRepo;
            CourseSection toAdd;

            IList<StudentHold> studentHolds = new List<StudentHold>();
            using (context)
            {
                csRepo = new CourseSectionRepo(context);
                rRepo = new RegistrationRepo(context);
                hRepo = new StudentHoldRepo(context);

                toAdd = csRepo.GetCourseSectionById(id);
                studentHolds = hRepo.GetAllStudentHoldsById(CustomUser.User.Id);
                RegistrationViewModel viewModel = new RegistrationViewModel();

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