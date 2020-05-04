using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using BryantUniversity.Security;
using BryantUniversity.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class TranscriptController : Controller
    {
        private Context context = new Context();

        public CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }
        // GET: Transcript
        [HttpGet]
        public ActionResult Index()
        {
            TranscriptViewModel viewModel = new TranscriptViewModel();
            SemesterPeriodRepo spRepo;
            using (context)
            {
                spRepo = new SemesterPeriodRepo(context);
                viewModel.PopulateSelectList(spRepo.GetAllSemesterPeriods());
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(TranscriptViewModel pViewModel)
        {
            GradesRepo gRepo;
            RegistrationRepo rRepo;
            SemesterPeriodRepo spRepo;

            TranscriptViewModel viewModel = new TranscriptViewModel();
            IList<Grade> userGrades;
            IList<Registration> registered;
            using (context)
            {
                rRepo = new RegistrationRepo(context);
                gRepo = new GradesRepo(context);
                spRepo = new SemesterPeriodRepo(context);

                viewModel.PopulateSelectList(spRepo.GetAllSemesterPeriods());
                //GetRegistrationByUserIdAndPeriodId
                userGrades = gRepo.GetGradesByUserAndSemesterPeriodId(CustomUser.User.Id, pViewModel.PeriodId);
                registered = rRepo.GetRegistrationByUserId(CustomUser.User.Id);

                if (userGrades.Count >= 1 && registered.Count >= 1)
                {
                    float gpa = 0.0f;
                    foreach (Grade grade in userGrades)
                    {
                        viewModel.AllGradesClasses.Add(grade.Registration);
                        viewModel.AllNonGradedClasses = registered;

                        gpa += grade.FinalGrade;

                        if (gpa >= 94) { viewModel.TermGpa = 4.0f; }
                        else if(gpa == 93) { viewModel.TermGpa = 3.9f ; }
                        else if(gpa == 92) { viewModel.TermGpa = 3.8f; }
                        else if(gpa == 91) { viewModel.TermGpa = 3.7f; }
                        else if(gpa == 90) { viewModel.TermGpa = 3.6f; }
                        else if (gpa == 89) { viewModel.TermGpa = 3.5f; }
                        else if (gpa == 88) { viewModel.TermGpa = 3.4f; }
                        else if (gpa == 87) { viewModel.TermGpa = 3.3f; }
                        else if (gpa == 86) { viewModel.TermGpa = 3.2f; }
                        else if (gpa == 85) { viewModel.TermGpa = 3.1f; }
                        else if (gpa == 84) { viewModel.TermGpa = 3.0f; }
                        else if (gpa == 83) { viewModel.TermGpa = 2.9f; }
                        else if (gpa == 82) { viewModel.TermGpa = 2.8f; }
                    }
                    return View(viewModel);
                    //SemesterPeriod semesterPeriod = registration.CourseSection.SemesterPeriod;
                }
            }
            return View(viewModel);
        }
    }
}