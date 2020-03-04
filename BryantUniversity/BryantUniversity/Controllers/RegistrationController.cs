using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class RegistrationController : Controller
    {
        private Context context;

        public RegistrationController()
        {
            context = new Context();
        }

        [HttpGet]
        public ActionResult Index()
        {
            using (context)
            {
                IList<Course> courses = new CoursesRepo(context).GetAllCourses();
                return View(courses);
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
            using (context)
            {
                User currUser = new UserRepo(context).GetByEmail(User.Identity.Name);
                CourseSection courseSection = new CourseSectionRepo(context).GetCourseSectionById(id);
                Schedule schedule = new Schedule(currUser, courseSection);
                new ScheduleRepo(context).Insert(schedule);
                return RedirectToAction("Index");
            }
        }
    }
}