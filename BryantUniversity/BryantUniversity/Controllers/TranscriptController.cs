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
            using (context)
            {
                rRepo = new RegistrationRepo(context);
                gRepo = new GradesRepo(context);
                spRepo = new SemesterPeriodRepo(context);

                viewModel.PopulateSelectList(spRepo.GetAllSemesterPeriods());
                //GetRegistrationByUserIdAndPeriodId
                userGrades = gRepo.GetGradesByUserId(CustomUser.User.Id, pViewModel.PeriodId);

                if (userGrades.Count >= 1)
                {
                    float gpa = 0.0f;
                    foreach (Grade grade in userGrades)
                    {
                        viewModel.AllGradesClasses.Add(grade.Registration);

                        gpa += grade.FinalGrade;
                        if (gpa >= 95)
                        {
                            viewModel.TermGpa = 4.0f;

                        }
                    }
                    return View(viewModel);
                    //SemesterPeriod semesterPeriod = registration.CourseSection.SemesterPeriod;
                }
                else
                {
                    viewModel.HasClasses = false;
                }

            }
            return View(viewModel);
        }
    }
}