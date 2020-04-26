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
                IList<Registration> schedules = new RegistrationRepo(context).GetScheduleByUserId(currUser.Id);
                return View(schedules);
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
            CourseSection toAdd;
            using (context)
            {
                csRepo = new CourseSectionRepo(context);
                rRepo = new RegistrationRepo(context);
                toAdd = csRepo.GetCourseSectionById(id);

                RegistrationViewModel viewModel = new RegistrationViewModel();

                SemesterPeriod toAddPeriod = toAdd.SemesterPeriod;

                IList<Registration> registrations = rRepo.GetRegistrationByUserAndCourseSection(CustomUser.User.Id, id);
                IList<CourseSection> registeredCourseSections = new List<CourseSection>();

                foreach(Registration registration in registrations)
                {
                    
                    if(registration.CourseSectionId == id || registration.CourseSection.SemesterPeriod == toAddPeriod)
                    {
                        viewModel.Conflict = true;
                        return View(viewModel);
                    }
                    //registeredCourseSections.Add(registration.CourseSection);

                }

                Registration userCourseSection = new Registration(CustomUser.User.Id, toAdd.Id);
                rRepo.Insert(userCourseSection);
            }
            return RedirectToAction("Index", "Schedule");
        }
    }
}