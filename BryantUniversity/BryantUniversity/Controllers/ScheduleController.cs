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
    public class ScheduleController : Controller
    {
        private Context context;

        public CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }

        public ScheduleController()
        {
            context = new Context();
        }

        [httpsGet]
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

        [httpsPost]
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

        //[httpsGet]
        //public ActionResult Courses(int departmentId, )
        //

        //    return View(cViewModel);
        //}
        // GET: Schedule
    }
}