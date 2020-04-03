using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using BryantUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class CourseSectionController : Controller
    {
        private Context context;

        public CourseSectionController()
        {
            context = new Context();
        }

        [HttpGet]
        public ActionResult IndexCourse()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            CourseSectionRepo csRepo;
            CourseSectionViewModel viewModel;
            
            using (context)
            {
                csRepo = new CourseSectionRepo(context);
                viewModel = new CourseSectionViewModel();
                IList<CourseSection> courseSections = csRepo.GetAllCourseSections();
            }

            return View("Index", viewModel);
        }
    }
}