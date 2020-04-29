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
        public ActionResult Index()
        {
            GradesRepo gRepo;
            SemesterPeriodRepo spRepo;
            RegistrationRepo rRepo;
            UserRepo uRepo;

            TranscriptViewModel viewModel = new TranscriptViewModel();
            IList<Grade> userGrades;
            using (context)
            {
                gRepo = new GradesRepo(context);


                userGrades = gRepo.GetGradesByUserId(CustomUser.User.Id, 1);

                if (userGrades.Count >= 1)
                {
                    float gpa = 0.0f;
                    foreach(Grade grade in userGrades)
                    {
                        gpa += grade.FinalGrade;
                        if(gpa>=95)
                        {
                            viewModel.FinalGPA = 4.0f;

                            return View(viewModel);
                        }
                    }
     
                    //SemesterPeriod semesterPeriod = registration.CourseSection.SemesterPeriod;
                }
                else
                {

                }

            }
            return View();
        }
    }
}