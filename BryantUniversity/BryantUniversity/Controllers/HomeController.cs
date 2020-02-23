using BryantUniversity.Data;
using BryantUniversity.Models.Repo;
using BryantUniversity.ViewModels;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private Context context = new Context();
        [AllowAnonymous]
        public ActionResult Calendar()
        {
            var viewModel = new SemesterDetailsViewModel();
            CalendarRepo cRepo = new CalendarRepo(context);

            viewModel.semesterDetails = cRepo.GetAllCalendarEvents();
            return View(viewModel);
        }

        public ActionResult Calendar(SemesterDetailsViewModel viewModel)
        {
                   
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

       
        public ActionResult Catalog()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            return View();
        }
    }
}
