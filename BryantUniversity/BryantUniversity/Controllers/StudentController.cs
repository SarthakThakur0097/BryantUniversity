using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using BryantUniversity.Security;
using BryantUniversity.ViewModels;
using System.Collections.Generic;
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

        [HttpGet]
        public ActionResult ViewHold()
        {
            StudentHoldViewModel viewModel = new StudentHoldViewModel();
            StudentHoldRepo shRepo;

            using (context)
            {
                shRepo = new StudentHoldRepo(context);
                viewModel.UserHolds = shRepo.GetAllStudentHoldsByUserId(CustomUser.User.Id);
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Attendancebook(int id)
        {
            AttendanceRepo aRepo;
            AttendancebookViewModel viewModel = new AttendancebookViewModel();

            using (context)
            {
                aRepo = new AttendanceRepo(context);
                viewModel.Students = aRepo.GetAllAttendanceByUserId(id);

            }
            return View(viewModel);
        }

        [Authorize(Roles = "2")]
        [HttpGet]
        public ActionResult Attendance(int id, int cid)
        {
            StudentAttendanceViewModel viewModel = new StudentAttendanceViewModel();

            CourseSectionRepo cRepo;
            UserRepo uRepo;

            using (context)
            {
                uRepo = new UserRepo(context);
                cRepo = new CourseSectionRepo(context);

                viewModel.Student = uRepo.GetById(id);
                viewModel.CourseSection = cRepo.GetCourseSectionById(cid);
            }
            return View(viewModel);
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public ActionResult ScheduleAdmin(int studentId)
        {
            ScheduleViewModel viewModel = new ScheduleViewModel();
            RegistrationRepo rRepo;
            using (context)
            {
                rRepo = new RegistrationRepo(context);

                viewModel.RegisteredClasses = rRepo.GetRegistrationByUserId(studentId);
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
        public ActionResult DegreeAudit()
        {
            DegreeAuditViewModel viewModel = new DegreeAuditViewModel();

            GradesRepo gRepo;
            StudentMajorRepo sMRepo;
            MajorRepo mRepo;
            MajorRequirmentsRepo mrRepo;

            using (context)
            {
                gRepo = new GradesRepo(context);
                sMRepo = new StudentMajorRepo(context);
                mrRepo = new MajorRequirmentsRepo(context);

                mRepo = new MajorRepo(context);
                viewModel.AllCourses = gRepo.GetAllGradesByUserId(CustomUser.User.Id);
                viewModel.StudentMajor = sMRepo.GetByStudentId(CustomUser.User.Id);
                viewModel.MajorRequirements = mrRepo.GetAllMajorRequirementsByMajor(viewModel.StudentMajor.MajorId); 
            }
            return View(viewModel);
        }


        [HttpGet]
        public ActionResult DegreeAuditAdmin(int studentId)
        {
            DegreeAuditViewModel viewModel = new DegreeAuditViewModel();

            GradesRepo gRepo;
            StudentMajorRepo sMRepo;
            MajorRepo mRepo;
            MajorRequirmentsRepo mrRepo;

            using (context)
            {
                gRepo = new GradesRepo(context);
                sMRepo = new StudentMajorRepo(context);
                mrRepo = new MajorRequirmentsRepo(context);

                mRepo = new MajorRepo(context);
                viewModel.AllCourses = gRepo.GetAllGradesByUserId(studentId);
                viewModel.StudentMajor = sMRepo.GetByStudentId(studentId);
                viewModel.MajorRequirements = mrRepo.GetAllMajorRequirementsByMajor(viewModel.StudentMajor.MajorId);
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            UserRepo uRepo;
            StudentDetailsViewModel viewModel = new StudentDetailsViewModel();

            using (context)
            {
                uRepo = new UserRepo(context);
                viewModel.Student = uRepo.GetById(id);
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult TranscriptAdmin(int id)
        {
            TranscriptViewModel viewModel = new TranscriptViewModel();
            StudentMajorRepo sRepo;
            MajorRequirmentsRepo mRepo;
            GradesRepo gRepo;
            RegistrationRepo rRepo;
            IList<Grade> AllClasses = new List<Grade>();
            IList<Registration> AllRegistrations = new List<Registration>();
            IList<Registration> PendingGrades = new List<Registration>();

            using (context)
            {
                sRepo = new StudentMajorRepo(context);
                mRepo = new MajorRequirmentsRepo(context);
                gRepo = new GradesRepo(context);
                rRepo = new RegistrationRepo(context);

                viewModel.AllGradesClasses = gRepo.GetAllGradesByUserId(id);
                viewModel.StudentMajor = sRepo.GetByStudentId(id);

            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Transcript()
        {
            TranscriptViewModel viewModel = new TranscriptViewModel();
            StudentMajorRepo sRepo;
            MajorRequirmentsRepo mRepo;
            GradesRepo gRepo;
            RegistrationRepo rRepo;
            IList<Grade> AllClasses = new List<Grade>();
            IList<Registration> AllRegistrations = new List<Registration>();
            IList<Registration> PendingGrades = new List<Registration>();

            using (context)
            {
                sRepo = new StudentMajorRepo(context);
                mRepo = new MajorRequirmentsRepo(context);
                gRepo = new GradesRepo(context);
                rRepo = new RegistrationRepo(context);

                viewModel.AllGradesClasses = gRepo.GetAllGradesByUserId(CustomUser.User.Id);

                viewModel.StudentMajor = sRepo.GetByStudentId(CustomUser.User.Id);
                
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Advisors()
        {
            AdvisorsViewModel viewModel = new AdvisorsViewModel();
            AdviserRepo aRepo;

            using (context)
            {
                aRepo = new AdviserRepo(context);
                viewModel.Advisors = aRepo.GetAllAdvisorsStudentId(CustomUser.User.Id);

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

        [HttpGet]
        public ActionResult Gradebook(int id)
        {
            GradesRepo gRepo;
            LetterGradesRepo rRepo;
            GradebookViewModel viewModel = new GradebookViewModel();

            using (context)
            {
                rRepo = new LetterGradesRepo(context);
                gRepo = new GradesRepo(context);
                viewModel.AllGrades = gRepo.GetAllGradesByUserId(id);
                viewModel.PopulateSelectList(rRepo.GetAllLetterGrades());
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Gradebook(int id, int registrationId, GradebookViewModel viewModel)
        {
            GradesRepo gRepo;

            using (context)
            {
                gRepo = new GradesRepo(context);
                Grade newGrade = new Grade(viewModel.LetterGradeId, registrationId);
                gRepo.Update(newGrade);
            }
            return RedirectToAction("Gradebook");

        }

        [HttpPost]
        public ActionResult Grades(GradesViewModel viewModel)
        {
            SemesterPeriodRepo spRepo;
            RegistrationRepo rRepo;
            GradesRepo gRepo;

            
            using (context)
            {
                spRepo = new SemesterPeriodRepo(context);
                gRepo = new GradesRepo(context);
                rRepo = new RegistrationRepo(context);

                
                viewModel.PopulateSelectList(spRepo.GetAllSemesterPeriods());
                viewModel.Grades = gRepo.GetGradesByUserAndSemesterPeriodId(CustomUser.User.Id, viewModel.PeriodId);

                if(viewModel.Grades.Count == 0)
                {
                    viewModel.RegisteredClasses = rRepo.GetRegistrationByUserIdAndPeriodId(CustomUser.User.Id, viewModel.PeriodId);

                    if (viewModel.RegisteredClasses != null)
                    {
                        if (viewModel.RegisteredClasses.Count > 0)
                        {
                            return View(viewModel);
                        }
                    }
                }
                else if(viewModel.Grades.Count >= 1)
                {
              
                    viewModel.SemesterGpa = ConvertToFourPointScale(GetSemesterGpa(viewModel.Grades));
                    viewModel.CumulativeGpa = ConvertToFourPointScale(GetCumulativeGpa(gRepo.GetAllGradesByUserId(CustomUser.User.Id)));
                }
            }

            return View(viewModel);
        }

        public double? GetSemesterGpa(IList<Grade> grades)
        {
            int totalNonNullGrades = 0;

            double? cumlutiveTotal = 0.0;
            foreach (var toCalc in grades)
            {
                if (toCalc.LetterGrade != null)
                {
                    totalNonNullGrades++;
                    switch (toCalc.LetterGrade.GradeVal.Value)
                    {
                        case "A":
                            cumlutiveTotal += 95;
                            break;
                        case "A-":
                            cumlutiveTotal += 91;
                            break;
                        case "B+":
                            cumlutiveTotal += 88;
                            break;
                        case "B":
                            cumlutiveTotal += 85;
                            break;
                        case "B-":
                            cumlutiveTotal += 83;
                            break;
                        case "C+":
                            cumlutiveTotal += 78;
                            break;
                        case "C":
                            cumlutiveTotal += 75;
                            break;
                        case "C-":
                            cumlutiveTotal += 71;
                            break;
                        case "D+":
                            cumlutiveTotal += 68;
                            break;
                        case "F":
                            cumlutiveTotal += 0.0;
                            break;
                    }
                }
                if(totalNonNullGrades == 0)
                {
                    return -1;
                }
               
            }
            double? semesterGpa = cumlutiveTotal / totalNonNullGrades;

            return semesterGpa;
        }

        public double? GetCumulativeGpa(IList<Grade> grades)
        {
            int totalNonNullGrades = 0;
            double? cumlutiveTotal = 0.0;
            foreach (var toCalc in grades)
            {
                if (toCalc.LetterGrade != null)
                {
                    totalNonNullGrades++;
                    switch (toCalc.LetterGrade.GradeVal.Value)
                    {
                        case "A":
                            cumlutiveTotal += 95;
                            break;
                        case "A-":
                            cumlutiveTotal += 91;
                            break;
                        case "B+":
                            cumlutiveTotal += 88;
                            break;
                        case "B":
                            cumlutiveTotal += 85;
                            break;
                        case "B-":
                            cumlutiveTotal += 83;
                            break;
                        case "C+":
                            cumlutiveTotal += 78;
                            break;
                        case "C":
                            cumlutiveTotal += 75;
                            break;
                        case "C-":
                            cumlutiveTotal += 71;
                            break;
                        case "D+":
                            cumlutiveTotal += 68;
                            break;
                        case "F":
                            cumlutiveTotal += 0.0;
                            break;
                    }
                }
                if (totalNonNullGrades == 0)
                {
                    return -1;
                }
            }
            double? semesterGpa = cumlutiveTotal / totalNonNullGrades;

            return semesterGpa;
        }

        public double? ConvertToFourPointScale(double? numeric)
        {
            if (numeric <= 100 && numeric >= 97 || (numeric <= 96 && numeric >= 93))
            {
                return 4.0;
            }
            else if (numeric >= 92 && numeric >= 90)
            {
                return 3.7; 
            }
            else if (numeric >= 90 && numeric >= 89)
            {
                return 3.6;
            }
            else if (numeric >= 89 && numeric >= 87)
            {
                return 3.5;
            }
            else if (numeric >= 87 && numeric >= 85)
            {
                return 3.3;
            }
            else if (numeric >= 85 && numeric >= 83)
            {
                return 3.1;
            }
            else if (numeric >= 81 && numeric >= 79)
            {
                return 2.9;
            }
            else if (numeric >= 79 && numeric >= 77)
            {
                return 2.7;
            }
            else if (numeric >= 77 && numeric >= 75)
            {
                return 2.5;
            }
            else if (numeric >= 75 && numeric >= 73)
            {
                return 2.3;
            }
            else if (numeric >= 73 && numeric >= 71)
            {
                return 2.1;
            }
            else if (numeric >= 71 && numeric >= 69)
            {
                return 1.9;
            }
            else if (numeric >= 67 && numeric >= 65)
            {
                return 1.5;
            }
            else if(numeric == -1)
            {
                return -1;
            }
            else
            {
                return 1.0;
            }
        }
    }
}