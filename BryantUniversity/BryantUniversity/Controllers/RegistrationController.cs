using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace BryantUniversity.Controllers
{
    public class RegistrationController : Controller
    {
        //For merge
        private Context context;

        public RegistrationController()
        {
            context = new Context();
        }

        // GET: Registeration
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            var viewModel = new UserViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserViewModel viewModel)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(viewModel.Password, 12);
            if (ModelState.IsValid)
            {
                // Create an instance of the user database model.
                User user = new User()
                {
                    Email = viewModel.Email,
                    HashedPassword = hashedPassword,
                    Name = viewModel.Name
                };

                // TODO Save the user to the database.
                var userRepo = new UserRepo(context);
                userRepo.Insert(user);
                // Create the authentication ticket (i.e. HTTP cookie).
                FormsAuthentication.SetAuthCookie(viewModel.Email, false);

                // Redirect the user to the "Home" page.
                return RedirectToAction("Index", "Bench");
            }

            return View(viewModel);
        }
    }
}