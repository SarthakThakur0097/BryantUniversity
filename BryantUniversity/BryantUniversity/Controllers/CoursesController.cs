using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using BryantUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        private Context context;

        public CoursesController()
        {
            context = new Context();
        }

        [HttpGet]
        public ActionResult Index()
        {
            CoursesRepo courseRepo;
            CourseViewModel viewModel;
            IList<Course> courses;
            using (context)
            {
                courseRepo = new CoursesRepo(context);
                viewModel = new CourseViewModel();
                courses = courseRepo.GetAllCourses();
            }

            viewModel.Courses = courses;

            return View("Index", viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CourseViewModel formModel = new CourseViewModel();
            return View("Create", formModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course formModel)
        {
            CoursesRepo courseRepo;

            using (context)
            {
                courseRepo = new CoursesRepo(context);

                try
                {
                    var course = new Course(formModel.CourseTitle, formModel.Description, formModel.Credits, formModel.Level);
                    courseRepo.Insert(course);

                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    HandleDbUpdateException(ex);
                }
            }
            return View();
        }

        private void HandleDbUpdateException(DbUpdateException ex)
        {
            if (ex.InnerException != null && ex.InnerException.InnerException != null)
            {
                SqlException sqlException =
                    ex.InnerException.InnerException as SqlException;
                if (sqlException != null && sqlException.Number == 2627)
                {
                    ModelState.AddModelError("CourTitle", "This course is already exists.");
                }
            }
        }
    }

}