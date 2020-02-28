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

        [HttpPost]
        public ActionResult Calendar(SemesterDetailsViewModel viewModel)
        {

            return View();
        }


        public ActionResult Index()
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
