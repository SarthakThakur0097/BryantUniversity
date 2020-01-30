using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BryantUniversity.Controllers
{
    public class LoginController : Controller
    {
        private Context context;

        public LoginController()
        {
            context = new Context();
        }

        // GET: Login
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
                // TODO Get the user record from the database by their email.
                var userRepo = new UserRepo(context);

                User user = userRepo.GetByEmail(viewModel.Email);

                // If we didn't get a user back from the database
                // or if the provided password doesn't match the password stored in the database
                // then login failed.
                if (user == null || !BCrypt.Net.BCrypt.Verify(viewModel.Password, user.HashedPassword))
                {
                    ModelState.AddModelError("", "Login failed.");
                }
            }

            if (ModelState.IsValid)
            {
                // Login the user.
                FormsAuthentication.SetAuthCookie(viewModel.Email, false);

                // Send them to the home page.
                return RedirectToAction("register", "Registration");
            }

            return View(viewModel);
        }
    }
}