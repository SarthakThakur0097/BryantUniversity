using BryantUniversity.Data;
using BryantUniversity.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class CourseSectionController : Controller
    {
        private Context context;

        public CourseSectionController()
        {
            context = new Context();
        }

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    CourseSectionRepo csRepo;
        //    CourseViewModel viewModel;
        //    IList<Course> courses;
        //    using (context)
        //    {
        //        courseRepo = new CoursesRepo(context);
        //        viewModel = new CourseViewModel();
        //        courses = courseRepo.GetAllCourses();
        //    }

        //    viewModel.Courses = courses;

        //    return View("Index", viewModel);
        //}
    }
}