using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class ResearcherController : Controller
    {
        // GET: Researcher
        [HttpGet]
        public ActionResult StudentStasitics()
        {
            return View();
        }
    }
}