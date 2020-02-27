using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class FacultyController : Controller
    {

        private Context context;

        public FacultyController()
        {
            context = new Context();
        }

        // GET: Faculty
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var userViewModel = new UserViewModel();
            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userViewModel.Password);
                User user = new User(userViewModel.Email, hashedPassword, userViewModel.Name);
                var repository = new UserRepo(context);
                repository.Insert(user);

                var roleRepo = new UserRoleRepo(context);
                UserRole userRole = new UserRole();

                int userId = repository.GetById(user.Id).Id;

                switch (userViewModel.RoleType)
                {
                    case RoleType.Admin:
                        userRole = new UserRole(userId, 1);
                        break;
                    case RoleType.Faculty:
                        userRole = new UserRole(userId, 2);
                        break;
                    case RoleType.Researcher:
                        userRole = new UserRole(userId, 3);
                        break;
                    case RoleType.Student:
                        userRole = new UserRole(userId, 4);
                        break;
                    default:
                        break;
                }

                roleRepo.Insert(userRole);
                return RedirectToAction("Home", "Home");
            }

            return View(userViewModel);
        }
    }
}