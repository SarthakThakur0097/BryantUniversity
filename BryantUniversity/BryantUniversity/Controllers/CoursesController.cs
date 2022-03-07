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
    [AllowAnonymous]
    public class CoursesController : Controller
    {
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
        public ActionResult Prereq(int courseId)
        {
            DepartmentRepo dRepo;
            MajorPreRequisitesRepo reqRepo;
            CoursePreReqViewModel viewModel = new CoursePreReqViewModel();
            using (context)
            {
                dRepo = new DepartmentRepo(context);
                viewModel.PopulateDepermentSelectList(dRepo.GetAllDepartments());
                reqRepo = new MajorPreRequisitesRepo(context);
                viewModel.CoursesAndPreReqs = reqRepo.GetAllMajorPrequisitesForCourse(courseId);
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddPreq(int courseId, int departmentId)
        {
            CoursesRepo cRepo;
            CourseViewModel viewModel = new CourseViewModel();
            using (context)
            {
                cRepo = new CoursesRepo(context);
                viewModel.CoursePrereqId = courseId;
                viewModel.Courses = cRepo.GetByDepartment(departmentId);
            }

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult AddPreqPost(int courseId, int prereqId)
        {
            if (courseId == prereqId)
            {
                return View();
            }
            else
            {
                MajorPreRequisitesRepo mprRepo;
                MajorPreRequisite toAdd;
                using (context)
                {
                    mprRepo = new MajorPreRequisitesRepo(context);
                    toAdd = new MajorPreRequisite(prereqId, courseId);
                    mprRepo.Insert(toAdd);
                }

                return View();
            }
        }

        [HttpGet]
        public ActionResult Majors()
        {
            MajorRepo mRepo;
            MajorViewModel viewModel = new MajorViewModel();
            using (context)
            {
                mRepo = new MajorRepo(context);
                viewModel.Majors = mRepo.GetAllMajors();
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(CourseViewModel viewModel)
        {
            return View();
        }

        public ActionResult Create()
        {

            var viewModel = new CourseViewModel();
            DepartmentRepo dRepo;
            CourseLevelRepo clRepo;

            using (context)
            {
                dRepo = new DepartmentRepo(context);
                clRepo = new CourseLevelRepo(context);

                viewModel.PopulateDepermentSelectList(dRepo.GetAllDepartments());
                viewModel.PopulateLevelsSelectList(clRepo.GetAllCourseLevels());

            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel formModel)
        {
            using (context)
            {
                CoursesRepo courseRepo = new CoursesRepo(context); ;
                DepartmentRepo dRepo;
                CourseLevelRepo clRepo;
                MajorPreRequisitesRepo mPRepo;

                dRepo = new DepartmentRepo(context);
                clRepo = new CourseLevelRepo(context);
                mPRepo = new MajorPreRequisitesRepo(context);

                if (ModelState.IsValid)
                {
                    if(formModel.Credits <0 || formModel.Credits >4)
                    {
                        ModelState.AddModelError("", "Credits must be a value from 1 - 4");
                        formModel.PopulateDepermentSelectList(dRepo.GetAllDepartments());
                        formModel.PopulateLevelsSelectList(clRepo.GetAllCourseLevels());
                        return View(formModel);
                    }
                    Course doesCoursebyTitleIdExist = courseRepo.GetCourseByCourseTitleId(formModel.CourseTitleId);

                    if (doesCoursebyTitleIdExist != null)
                    {
                        ModelState.AddModelError("", "Course already exists");
                        formModel.PopulateDepermentSelectList(dRepo.GetAllDepartments());
                        formModel.PopulateLevelsSelectList(clRepo.GetAllCourseLevels());
                        formModel.SameTitleId = true;
                        return View(formModel);
                    }
                    else
                    {
                        formModel.PopulateDepermentSelectList(dRepo.GetAllDepartments());
                        formModel.PopulateLevelsSelectList(clRepo.GetAllCourseLevels());
                        try
                        {
                            var course = new Course(formModel.CourseTitleId, formModel.CourseTitle, formModel.Description, formModel.Credits, formModel.CourseLevelId, formModel.DepartmentId);
                            courseRepo.Insert(course);

                            Course cId = courseRepo.GetCourseByCourseTitleId(formModel.CourseTitleId);

                            return RedirectToAction("Index");
                        }
                        catch (DbUpdateException ex)
                        {
                            HandleDbUpdateException(ex);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "You must fill out all values");
                    formModel.PopulateDepermentSelectList(dRepo.GetAllDepartments());
                    formModel.PopulateLevelsSelectList(clRepo.GetAllCourseLevels());
                    return View(formModel);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DepartmentRepo dRepo;
            CourseLevelRepo clRepo;
            CoursesRepo courseRepo;
            CourseViewModel viewModel = new CourseViewModel();
            Course course;

            using (context)
            {
                courseRepo = new CoursesRepo(context);
                dRepo = new DepartmentRepo(context);
                clRepo = new CourseLevelRepo(context);
                viewModel.PopulateDepermentSelectList(dRepo.GetAllDepartments());
                viewModel.PopulateLevelsSelectList(clRepo.GetAllCourseLevels());
                course = courseRepo.GetById(id);
                viewModel.Id = course.Id;
                viewModel.CourseTitleId = course.CourseTitleId;
                viewModel.CourseTitle = course.CourseTitle;
                viewModel.Description = course.Description;
                viewModel.Credits = course.Credits;
                viewModel.CourseLevelId = course.CourseLevelId;
                viewModel.DepartmentId = course.DepartmentId;
            }

            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, CourseViewModel course)
        {
            DepartmentRepo dRepo;
            CourseLevelRepo clRepo;
            CoursesRepo courseRepo;
            Course newCourse;
            CourseViewModel viewModel = new CourseViewModel();
            using (context)
            {
                courseRepo = new CoursesRepo(context);
                try
                {
                    dRepo = new DepartmentRepo(context);
                    clRepo = new CourseLevelRepo(context);
                    newCourse = new Course(id, course.CourseTitleId, course.CourseTitle, course.Description, course.Credits, course.CourseLevelId, course.DepartmentId);
                    viewModel.PopulateDepermentSelectList(dRepo.GetAllDepartments());
                    viewModel.PopulateLevelsSelectList(clRepo.GetAllCourseLevels());
                    viewModel.Id = id;
                    viewModel.CourseTitle = course.CourseTitle;
                    viewModel.Description = course.Description;
                    viewModel.Credits = course.Credits;
                    viewModel.CourseLevel = course.CourseLevel;
                    viewModel.DepartmentId = course.DepartmentId;
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

        [HttpPost]
        public ActionResult DeletePreq(int courseId)
        {
            MajorPreRequisitesRepo mprRepo;

            using (context)
            {
                mprRepo = new MajorPreRequisitesRepo(context);
            }

            return View();
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
            Course checkPrereqs;
            MajorPreRequisitesRepo mprRepo = new MajorPreRequisitesRepo(context);
            CourseDeleteViewModel viewModel = new CourseDeleteViewModel();
            cRepo = new CoursesRepo(context);
            checkPrereqs = cRepo.GetAllPreReqsByCourseId(id);

            if (checkPrereqs.CourseMajorPreRequisites.Count >= 1)
            {
                viewModel.Course = checkPrereqs;

                return View(viewModel);
            }
            else if(checkPrereqs.CourseMajorPreRequisites.Count == 0)
            {
                IList<MajorPreRequisite> preReqsToDelete = mprRepo.GetByPrereqId(checkPrereqs.Id);
                if(preReqsToDelete.Count>1)
                {

                }
                cRepo.Delete(checkPrereqs);
                TempData["Deleted"] = true;
            }

            return RedirectToAction("Index", "Courses");
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
                    toDelete = new Course { Id = id };
                    cRepo.Delete(toDelete);

                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    HandleDbUpdateException(ex);

                    return RedirectToAction("Index");
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
            DepartmentRepo dRepo;
            CoursesRepo cRepo;
            MajorPreRequisitesRepo reqRepo;

            using (context)
            {
                dRepo = new DepartmentRepo(context);
                cRepo = new CoursesRepo(context);
                viewModel.PopulateDepermentSelectList(dRepo.GetAllDepartments());
                reqRepo = new MajorPreRequisitesRepo(context);
                viewModel.Courses = cRepo.GetAllCoursesAndPreReqsByDepartment(viewModel.DepartmentId);
            }

            return View(viewModel);
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