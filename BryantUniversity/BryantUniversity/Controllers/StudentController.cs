using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using BryantUniversity.Security;
using BryantUniversity.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    [Authorize(Roles = "4")]
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
        public ActionResult Drop()
        {
            DropViewModel viewModel = new DropViewModel();
            SemesterPeriodRepo sRepo;
            GradesRepo gRepo;
            RegistrationRepo rRepo;
            IList<Registration> allRegisterations = new List<Registration>();
            List<Registration> nonGraded = new List<Registration>();

            using (context)
            {
                sRepo = new SemesterPeriodRepo(context);
                rRepo = new RegistrationRepo(context);
                gRepo = new GradesRepo(context);

                allRegisterations = rRepo.GetRegistrationByUserIdAndPeriodId(CustomUser.User.Id, 1);

                foreach(var grade in allRegisterations)
                {
                    if(!gRepo.ContainsRegistration(grade.Id))
                    {
                        nonGraded.Add(grade);
                    }
                }
                viewModel.NonGraded = nonGraded;
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Drop(ScheduleViewModel viewModel)
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
        public ActionResult Transcript()
        {
            TranscriptViewModel viewModel = new TranscriptViewModel();
            StudentMajorRepo sRepo;
            MajorRequirmentsRepo mRepo;

            using (context)
            {
                sRepo = new StudentMajorRepo(context);
                mRepo = new MajorRequirmentsRepo(context);
                viewModel.StudentMajor = sRepo.GetByStudentId(CustomUser.User.Id);
                viewModel.MajorRequirements = mRepo.GetAllMajorRequirementsByMajor(viewModel.StudentMajor.MajorId);
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
                    else if (calculatedGrade < 94 && calculatedGrade >= 93)
                    {
                        viewModel.Gpa = 3.8;
                    }
                    else if(calculatedGrade < 93 && calculatedGrade >= 92)
                    {
                        viewModel.Gpa = 3.7;
                    }
                    else if (calculatedGrade < 92 && calculatedGrade >= 91)
                    {
                        viewModel.Gpa = 3.6;
                    }
                    else if (calculatedGrade < 91 && calculatedGrade >= 90)
                    {
                        viewModel.Gpa = 3.5;
                    }
                    else if (calculatedGrade < 90 && calculatedGrade >= 89)
                    {
                        viewModel.Gpa = 3.4;
                    }
                    else if (calculatedGrade < 89 && calculatedGrade >= 88)
                    {
                        viewModel.Gpa = 3.3;
                    }
                    else if (calculatedGrade < 88 && calculatedGrade >= 87)
                    {
                        viewModel.Gpa = 3.2;
                    }
                    else if (calculatedGrade < 87 && calculatedGrade >= 86)
                    {
                        viewModel.Gpa = 3.1;
                    }
                    else if (calculatedGrade < 86 && calculatedGrade >= 85)
                    {
                        viewModel.Gpa = 3.0;
                    }
                    else if (calculatedGrade < 85 && calculatedGrade >= 84)
                    {
                        viewModel.Gpa = 2.9;
                    }
                    else if (calculatedGrade < 84 && calculatedGrade >= 83)
                    {
                        viewModel.Gpa = 2.8;
                    }
                    else if (calculatedGrade < 83 && calculatedGrade >= 82)
                    {
                        viewModel.Gpa = 2.7;
                    }
                    else if (calculatedGrade < 82 && calculatedGrade >= 81)
                    {
                        viewModel.Gpa = 2.6;
                    }
                    else if (calculatedGrade < 81 && calculatedGrade >= 80)
                    {
                        viewModel.Gpa = 2.7;
                    }
                    else if (calculatedGrade < 80 && calculatedGrade >= 79)
                    {
                        viewModel.Gpa = 2.5;
                    }
                    else if (calculatedGrade < 79 && calculatedGrade >= 78)
                    {
                        viewModel.Gpa = 2.6;
                    }
                    else if (calculatedGrade < 77 && calculatedGrade >= 76)
                    {
                        viewModel.Gpa = 2.5;
                    }
                    else if (calculatedGrade < 75 && calculatedGrade >= 74)
                    {
                        viewModel.Gpa = 2.4;
                    }
                    else if (calculatedGrade < 74 && calculatedGrade >= 73)
                    {
                        viewModel.Gpa = 2.3;
                    }
                    else if (calculatedGrade < 72 && calculatedGrade >= 71)
                    {
                        viewModel.Gpa = 2.2;
                    }
                    else if (calculatedGrade < 70 && calculatedGrade >= 69)
                    {
                        viewModel.Gpa = 2.1;
                    }
                    else if (calculatedGrade < 68 && calculatedGrade >= 67)
                    {
                        viewModel.Gpa = 2.0;
                    }
                    else if (calculatedGrade < 66 && calculatedGrade >= 65)
                    {
                        viewModel.Gpa = 1.9;
                    }
                    else if (calculatedGrade < 64 && calculatedGrade >= 63)
                    {
                        viewModel.Gpa = 1.8;
                    }
                    else
                    {
                        viewModel.Gpa = 1.5;
                    }
                }
            }

            return View(viewModel);
        }
    }
}