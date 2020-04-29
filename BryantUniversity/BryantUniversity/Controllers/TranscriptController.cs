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

            TranscriptVieModel viewModel = new TranscriptVieModel();
            IList<Grade> userGrades;
            using (context)
            {
                gRepo = new GradesRepo(context);
                uRepo = new UserRepo(context);
                spRepo = new SemesterPeriodRepo(context);
                rRepo = new RegistrationRepo(context);

                userGrades = gRepo.GetGradeByUserId(CustomUser.User.Id);

                if (userGrades.Count >= 1)
                {
            
     
                    //SemesterPeriod semesterPeriod = registration.CourseSection.SemesterPeriod;

                    viewModel.PopulateSelectList(spRepo.GetAllSemesterPeriods());
                }
                else
                {

                }

            }
            return View();
        }
    }
}