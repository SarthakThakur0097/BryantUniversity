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

        [Authorize(Roles = "2")]
        [HttpGet]
        public ActionResult Attendance(int id, int CourseSectionId)
        {
            StudentAttendanceViewModel viewModel = new StudentAttendanceViewModel();

            CourseSectionRepo cRepo;
            UserRepo uRepo;

            using (context)
            {
                uRepo = new UserRepo(context);
                cRepo = new CourseSectionRepo(context);

                viewModel.Student = uRepo.GetById(id);
                viewModel.CourseSection = cRepo.GetCourseSectionById(CourseSectionId);
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
                }
                if (viewModel.RegisteredClasses != null)
                {
                    if (viewModel.RegisteredClasses.Count > 0)
                    {
                        return View(viewModel);
                    }
                }
                double? calculatedGrade = 0.0;

                foreach(var toCalc in viewModel.Grades)
                {
                    
                }
            }

            return View(viewModel);
        }
    }
}