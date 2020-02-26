using BryantUniversity.Models.Repo;
using BryantUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BryantUniversity.Data;

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
            CalendarRepo cRepo = new CalendarRepo(context);

            viewModel.semesterDetails = cRepo.GetAllCalendarEvents();
            return View(viewModel);
  
        }
    }
}