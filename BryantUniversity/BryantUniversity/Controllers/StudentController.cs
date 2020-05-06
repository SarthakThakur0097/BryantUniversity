using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using BryantUniversity.Security;
using BryantUniversity.ViewModels;

using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class StudentController : Controller
    {
        Context context;

        public StudentController()
        {
            context = new Context();
        }

        public CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }

        [HttpGet]
        public ActionResult Schedule()
        {
            SemesterPeriodRepo sRepo;
            ScheduleViewModel viewModel = new ScheduleViewModel();
            using (context)
            {
                sRepo = new SemesterPeriodRepo(context);
                viewModel.PopulateSelectList(sRepo.GetAllSemesterPeriods());
            }

            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult Schedule(ScheduleViewModel viewModel)
        {
            SemesterPeriodRepo sRepo;
            RegistrationRepo rRepo;
            using (context)
            {
                sRepo = new SemesterPeriodRepo(context);
                rRepo = new RegistrationRepo(context);
                viewModel.PopulateSelectList(sRepo.GetAllSemesterPeriods());
               
                viewModel.RegisteredClasses = rRepo.GetRegistrationByUserIdAndPeriodId(CustomUser.User.Id, viewModel.PeriodId);
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Grades()
        {
            SemesterPeriodRepo spRepo;
            GradesViewModel viewModel = new GradesViewModel();

            using (context)
            {
                spRepo = new SemesterPeriodRepo(context);
                viewModel.PopulateSelectList(spRepo.GetAllSemesterPeriods());
            }
                return View(viewModel);
        }


        //public ActionResult AssignAdvisor()
        //{

        //}

        private void HandleDbUpdateException(DbUpdateException ex)

        [HttpPost]
        public ActionResult Grades(GradesViewModel viewModel)
        {
            SemesterPeriodRepo spRepo;
            GradesRepo gRepo;

            using (context)
            {
                spRepo = new SemesterPeriodRepo(context);
                gRepo = new GradesRepo(context);

                viewModel.PopulateSelectList(spRepo.GetAllSemesterPeriods());
                viewModel.Grades = gRepo.GetGradesByUserAndSemesterPeriodId(CustomUser.User.Id, viewModel.PeriodId);
                double calculatedGrade = 0.0;

                foreach(var toCalc in viewModel.Grades)
                {
                    if(viewModel.Grades.Count>1)
                    {
                        calculatedGrade += toCalc.FinalGrade / viewModel.Grades.Count;

                    }
                    else
                    {
                        calculatedGrade = toCalc.FinalGrade;
                    }
                    if (calculatedGrade>=95)
                    {
                        viewModel.Gpa = 4.0;
                    }
                    else if (calculatedGrade < 95 && calculatedGrade >= 94)
                    {
                        viewModel.Gpa = 3.9;
                    }
                    if (calculatedGrade < 94 && calculatedGrade >= 93)
                    {
                        viewModel.Gpa = 3.8;
                    }
                    if (calculatedGrade < 93 && calculatedGrade >= 92)
                    {
                        viewModel.Gpa = 3.7;
                    }
                    if (calculatedGrade < 92 && calculatedGrade >= 91)
                    {
                        viewModel.Gpa = 3.6;
                    }
                    if (calculatedGrade < 91 && calculatedGrade >= 90)
                    {
                        viewModel.Gpa = 3.5;
                    }
                    if (calculatedGrade < 90 && calculatedGrade >= 89)
                    {
                        viewModel.Gpa = 3.4;
                    }
                    if (calculatedGrade < 89 && calculatedGrade >= 88)
                    {
                        viewModel.Gpa = 3.3;
                    }
                    if (calculatedGrade < 88 && calculatedGrade >= 87)
                    {
                        viewModel.Gpa = 3.2;
                    }
                    if (calculatedGrade < 87 && calculatedGrade >= 86)
                    {
                        viewModel.Gpa = 3.1;
                    }
                    if (calculatedGrade < 86 && calculatedGrade >= 85)
                    {
                        viewModel.Gpa = 3.0;
                    }
                    if (calculatedGrade < 85 && calculatedGrade >= 84)
                    {
                        viewModel.Gpa = 2.9;
                    }
                    if (calculatedGrade < 84 && calculatedGrade >= 83)
                    {
                        viewModel.Gpa = 2.8;
                    }
                    if (calculatedGrade < 83 && calculatedGrade >= 82)
                    {
                        viewModel.Gpa = 2.7;
                    }
                    if (calculatedGrade < 82 && calculatedGrade >= 81)
                    {
                        viewModel.Gpa = 2.6;
                    }
                    if (calculatedGrade < 81 && calculatedGrade >= 80)
                    {
                        viewModel.Gpa = 2.7;
                    }
                    else
                    {
                        viewModel.Gpa = 2.0;
                    }
                }
            }

            return View(viewModel);
        }
    }
}