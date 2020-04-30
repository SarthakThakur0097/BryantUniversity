using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using BryantUniversity.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class GradesController : Controller
    {
        private Context context;

        public GradesController()
        {
            context = new Context();
        }
        // GET: Grades
        [HttpGet]
        public ActionResult Assign(int id, int rId)
        {
            UserDetailsViewModel student = new UserDetailsViewModel();
            UserRepo uRepo;

            using (context)
            {
                uRepo = new UserRepo(context);
                User toAssign = uRepo.GetById(id);
                
                student.Name = toAssign.Name;
                student.Email = toAssign.Email;
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult Assign(int id, int rId, UserDetailsViewModel viewModel)
        {
            UserRepo uRepo;
            RegistrationRepo rRepo;
            GradesRepo gRepo;

            using (context)
            {
                rRepo = new RegistrationRepo(context);
                gRepo = new GradesRepo(context);

                rRepo = new RegistrationRepo(context);

                IList<Registration> usersRegistration = rRepo.GetRegistrationByUserId(id);

                foreach(Registration registration in usersRegistration)
                {
                    if((registration.UserId == id && registration.CourseSectionId == rId))
                    {
                        Grade grade = new Grade(0, viewModel.Grade, registration.Id);
                        gRepo.Insert(grade);
                    }
                }

            }

            return View();
        }
    }
}