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
    public class RegisterationController : Controller
    {
        private Context context;

        public RegisterationController()
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
            if (ModelState.IsValid)
            {
                // Create an instance of the user database model.
                User user = new User()
                {
                    Email = viewModel.Email,
                    HashedPassword = viewModel.Password,
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