using BryantUniversity.ViewModels;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Calendar()
        {
            var viewModel = new SemesterDetailsViewModel();
           
            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
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