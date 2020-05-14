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

            object PreviousSemester = TempData["IsPreviousSemesterConflict"];
            object PartTimeTryFullTime = TempData["PartTimeTryFullTime"];
            object UnderGradTryGrad = TempData["UnderGradTryGrad"];
            object Success = TempData["Success"];
            object FullTimeOverFlow = TempData["FullTimeOverFlow"];
            object SpaceLeftInRoom = TempData["SpaceLeftInRoom"];
            object HasHold = TempData["HasHold"];
            object SameClass = TempData["SameClass"];
            object TimeConflict = TempData["TimeConflict"];
            object NotTakePreqs = TempData["NotTakePreqs"];
            object HasNotTakenPrereq = TempData["HasNotTakenPrereq"];
            if (PreviousSemester != null)
            {
                if ((bool)PreviousSemester)
                {
                    viewModel.IsPreviousSemesterConflict = true;
                }
            }
            else if (PartTimeTryFullTime != null)
            {
                if ((bool)PartTimeTryFullTime)
                {
                    viewModel.PartTimeTryFullTime = true;
                }
            }
            else if (UnderGradTryGrad != null)
            {
                if ((bool)UnderGradTryGrad)
                {
                    viewModel.UnderGradTryGrad = true;
                }
            }
            else if (FullTimeOverFlow != null)
            {
                if ((bool)FullTimeOverFlow)
                {
                    viewModel.FullTimeOverFlow = true;
                }
            }
            else if (SpaceLeftInRoom != null)
            {
                if (!(bool)SpaceLeftInRoom)
                {
                    viewModel.SpaceLeftInRoom = false;
                }
            }
            else if (HasHold != null)
            {
                if ((bool)HasHold)
                {
                    viewModel.HasHold = true;
                }
            }
            else if (SameClass != null)
            {
                if ((bool)SameClass)
                {
                    viewModel.SameClass = true;
                }
            }
            else if (TimeConflict != null)
            {
                if ((bool)TimeConflict)
                {
                    viewModel.TimeConflict = true;
                }
            }
            else if (Success != null)
            {
                if ((bool)Success)
                {
                    viewModel.Success = true;
                }
            }

            else if(NotTakePreqs != null)
            {
                if((bool)NotTakePreqs)
                {
                    viewModel.NotTakePreqs = true;
                }
            }
            else if(HasNotTakenPrereq != null)
            {
                if((bool)HasNotTakenPrereq)
                {
                    viewModel.HasNotTakenPrereq = true;
                }
            }

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