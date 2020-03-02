using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class StudentController : Controller
    {
        Context context;

        public StudentController()
        {
            context = new Context();
        }
        // GET: Student
        public ActionResult Index()
        {
            UserRoleRepo urRepo;
            UserViewModel viewModel = new UserViewModel();
            using (context)
            {
                urRepo = new UserRoleRepo(context);
                viewModel.Users = urRepo.GetUsersByRole(4);

        }
            return View(viewModel);
        }
    }
}