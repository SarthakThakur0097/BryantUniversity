using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using BryantUniversity.Security;
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
            RegistrationRepo sRepo;
            CourseSection toAdd;
            using (context)
            {
                csRepo = new CourseSectionRepo(context);
                sRepo = new RegistrationRepo(context);

                toAdd = csRepo.GetCourseSectionById(id);
                Registration userCourseSection = new Registration(CustomUser.User.Id, toAdd.Id);
                sRepo.Insert(userCourseSection);
            }
            return View("Index");
        }
    }
}