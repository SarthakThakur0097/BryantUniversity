using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using BryantUniversity.Security;
using BryantUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    [AllowAnonymous]
    public class ScheduleController : Controller
    {
        public ScheduleController()
        {
            context = new Context();
        }

        private Context context;

        public CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }

        [HttpGet]
        public ActionResult IndexAdmin(int studentId)
        {
            var viewModel = new SemesterDetailsViewModel();

            CalendarRepo cRepo;
            DepartmentRepo dRepo;
            SemesterPeriodRepo spRepo;

            using (context)
            {
                cRepo = new CalendarRepo(context);
                spRepo = new SemesterPeriodRepo(context);
                dRepo = new DepartmentRepo(context);
                viewModel.StudentId = studentId;
                viewModel.PopulateSelectList(spRepo.GetAllSemesterPeriods());
                viewModel.PopulateDepermentSelectList(dRepo.GetAllDepartments());
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult IndexAdmin(int studentId, SemesterDetailsViewModel viewModel)
        {
            using (context)
            {
                IList<SemesterPeriod> semesterPeriods;
                IList<Department> departments;
                DepartmentRepo deRepo;
                SemesterPeriodRepo spRepo;

                spRepo = new SemesterPeriodRepo(context);
                deRepo = new DepartmentRepo(context);

                semesterPeriods = spRepo.GetAllSemesterPeriods();
                departments = deRepo.GetAllDepartments();

                viewModel.PopulateSelectList(semesterPeriods);
                viewModel.PopulateDepermentSelectList(departments);
                viewModel.StudentId = studentId;
                if ((viewModel.DepartmentId < 1 || viewModel.PeriodId < 1))
                {
                    viewModel.DisplayCourses = false;
                    return RedirectToAction("IndexAdmin", viewModel);
                }
                else
                {
                    CoursesRepo cRepo = new CoursesRepo(context);

                    viewModel.Courses = cRepo.GetByDepartment(viewModel.DepartmentId);
                    viewModel.DisplayCourses = true;

                    return View(viewModel);
                }
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new SemesterDetailsViewModel();

            CalendarRepo cRepo;
            DepartmentRepo dRepo;
            SemesterPeriodRepo spRepo;

            using (context)
            {
                cRepo = new CalendarRepo(context);
                spRepo = new SemesterPeriodRepo(context);
                dRepo = new DepartmentRepo(context);

                viewModel.PopulateSelectList(spRepo.GetAllSemesterPeriods());
                viewModel.PopulateDepermentSelectList(dRepo.GetAllDepartments());
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(SemesterDetailsViewModel viewModel)
        {
            using (context)
            {
                IList<SemesterPeriod> semesterPeriods;
                IList<Department> departments;
                DepartmentRepo deRepo;
                SemesterPeriodRepo spRepo;

                spRepo = new SemesterPeriodRepo(context);
                deRepo = new DepartmentRepo(context);

                semesterPeriods = spRepo.GetAllSemesterPeriods();
                departments = deRepo.GetAllDepartments();

                viewModel.PopulateSelectList(semesterPeriods);
                viewModel.PopulateDepermentSelectList(departments);

                if ((viewModel.DepartmentId < 1 || viewModel.PeriodId < 1))
                {
                    viewModel.DisplayCourses = false;
                    return RedirectToAction("Index", viewModel);
                }
                else
                {
                    CoursesRepo cRepo = new CoursesRepo(context);

                    viewModel.Courses = cRepo.GetByDepartment(viewModel.DepartmentId);
                    viewModel.DisplayCourses = true;

                    return View(viewModel);
                }
            }
        }

        //[HttpGet]
        //public ActionResult Courses(int departmentId, )
        //

        //    return View(cViewModel);
        //}
        // GET: Schedule
    }
}