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
            if ((viewModel.DepartmentId < 1 || viewModel.PeriodId < 1))
            {

                DepartmentRepo deRepo;
                SemesterPeriodRepo spRepo;
                viewModel.DisplayCourses = false;
                using (context)
                {
                   
                    spRepo = new SemesterPeriodRepo(context);
                    deRepo = new DepartmentRepo(context);

                    viewModel.PopulateSelectList(spRepo.GetAllSemesterPeriods());
                    viewModel.PopulateDepermentSelectList(deRepo.GetAllDepartments());

                }
                return RedirectToAction("Index", viewModel);
            }

            CoursesRepo cRepo;
            DepartmentRepo dRepo;
            viewModel.DisplayCourses = true;
            using (context)
            {
                cRepo = new CoursesRepo(context);
                dRepo = new DepartmentRepo(context);

                viewModel.Courses = cRepo.GetByDepartment(viewModel.DepartmentId);
            }
            return RedirectToAction("Index", viewModel);
        }

        //[HttpGet]
        //public ActionResult Courses(int departmentId, )
        //

        //    return View(cViewModel);
        //}
        // GET: Schedule
    }
}