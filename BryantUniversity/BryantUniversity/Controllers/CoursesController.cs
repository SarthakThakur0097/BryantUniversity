using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using BryantUniversity.ViewModels;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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

        [HttpPost]
        public ActionResult Index(CourseViewModel viewModel)
        {

            return View();
        }
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel();
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel formModel)
        {
            CoursesRepo courseRepo;
            using (context)
            {
                courseRepo = new CoursesRepo(context);

                try
                {
                    var course = new Course(formModel.CourseTitleId,formModel.CourseTitle, formModel.Description, formModel.Credits, formModel.CourseLevel.Id, 1);
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CoursesRepo courseRepo;
            CourseViewModel viewModel = new CourseViewModel();
            Course course;
            using (context)
            {
                courseRepo = new CoursesRepo(context);
                course = courseRepo.GetById(id);

                
                viewModel.Id = course.Id;
                viewModel.CourseTitle = course.CourseTitle;
                viewModel.Description = course.Description;
                viewModel.Credits = course.Credits;
                viewModel.CourseLevel = course.CourseLevel;
                viewModel.DepartmentId = course.DepartmentId;
                
            }
            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, CourseViewModel course)
        {
            CoursesRepo courseRepo;
            Course newCourse;
            CourseViewModel viewModel = new CourseViewModel();
            using (context)
            {
                courseRepo = new CoursesRepo(context);
                try
                {
                    newCourse = new Course(course.CourseTitleId, course.CourseTitle, course.Description, course.Credits, course.CourseLevel.Id, course.DepartmentId);

                    viewModel.Id = id;
                    viewModel.CourseTitle = course.CourseTitle;
                    viewModel.Description = course.Description;
                    viewModel.Credits = course.Credits;
                    viewModel.CourseLevel = course.CourseLevel;
                    viewModel.DepartmentId = course.DepartmentId;
                    //viewModel.PopulateSelectList();

                    courseRepo.Update(newCourse);
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    HandleDbUpdateException(ex);
                    newCourse = null;
                }
            }
            return View("Edit", viewModel);
        }

        [HttpGet]
        public ActionResult Assign(int id)
        {
            CoursesRepo cRepo;
            Course viewModel;

            using (context)
            {
                cRepo = new CoursesRepo(context);
                viewModel = cRepo.GetById(id);
            }
                return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            CoursesRepo cRepo;
            Course confirmDelete;

            using(context)
            {
                cRepo = new CoursesRepo(context);
                confirmDelete = cRepo.GetById(id);
            }

            return View(confirmDelete);
        }

        [HttpPost]
        public ActionResult Delete(int id, Course course)
        {
            CoursesRepo cRepo;
            Course toDelete;

            using (context)
            {
                try
                {
                    cRepo = new CoursesRepo(context);
                    toDelete = cRepo.GetById(id);
                    cRepo.Delete(toDelete);

                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    HandleDbUpdateException(ex);
                    return RedirectToAction("Index");
                    //return View();
                }
            }
        }

        [HttpGet]
        public ActionResult Catalog()
        {
            DepartmentRepo dRepo;
            CoursePreReqViewModel viewModel = new CoursePreReqViewModel();
            using (context)
            {
                dRepo = new DepartmentRepo(context);
                viewModel.PopulateDepermentSelectList(dRepo.GetAllDepartments());
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Catalog(CoursePreReqViewModel viewModel)
        {
            CoursesRepo cRepo;
            IList<Course> courses;

            using (context)
            {
                cRepo = new CoursesRepo(context);
                courses = cRepo.GetAllCoursesAndPreReqsByDepartment(viewModel.DepartmentId);
            }

            return View(courses);
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