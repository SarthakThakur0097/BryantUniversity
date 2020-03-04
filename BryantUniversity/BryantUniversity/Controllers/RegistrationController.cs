using BryantUniversity.Data;
using BryantUniversity.Models;
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
                var repository = new CoursesRepo(context);
                IList<Course> courses = repository.GetAllCourses();
                return View(courses);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            using (context) {
                var repository = new CourseSectionRepo(context);
                IList<CourseSection> courseSections = repository.GetCourseSectionsByCourseId(id);
                return View(courseSections);
            }
        }
    }
}