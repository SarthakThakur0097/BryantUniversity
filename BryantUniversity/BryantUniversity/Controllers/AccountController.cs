using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace BryantUniversity.Controllers
{
    public class AccountController : Controller
    {
        private Context context;

        public AccountController()
        {
            context = new Context();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
            {
                var userRepo = new UserRepo(context);

                User user = userRepo.GetByEmail(viewModel.Email);
                if (user == null || !BCrypt.Net.BCrypt.Verify(viewModel.Password, user.HashedPassword))
                {
                    ModelState.AddModelError("", "Login failed.");
                }
            }

            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
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
                User user = new User(viewModel.Email, hashedPassword, viewModel.Name);
                var userRepo = new UserRepo(context);
                userRepo.Insert(user);
                FormsAuthentication.SetAuthCookie(viewModel.Email, false);

                return RedirectToAction("Login", "Account");
            }

            return View(viewModel);
        }
    }
}