using BryantUniversity.Models.Repo;
using BryantUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BryantUniversity.Data;
using BryantUniversity.Repo;

namespace BryantUniversity.Controllers
{
    [AllowAnonymous]
    public class CalendarController : Controller
    {
        private Context context = new Context();

        // GET: Calendar
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new SemesterDetailsViewModel();
            CalendarRepo cRepo;
            SemesterPeriodRepo spRepo;
            using (context)
            {
                cRepo = new CalendarRepo(context);
                spRepo = new SemesterPeriodRepo(context);
                viewModel.PopulateSelectList(context);
            }
                 
            return View(viewModel);
        }
    }
}