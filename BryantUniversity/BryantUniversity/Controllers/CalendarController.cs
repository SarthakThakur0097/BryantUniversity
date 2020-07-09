using BryantUniversity.Models.Repo;
using BryantUniversity.ViewModels;
using System.Web.Mvc;
using BryantUniversity.Data;
using BryantUniversity.Repo;

namespace BryantUniversity.Controllers
{
    [AllowAnonymous]
    public class CalendarController : Controller
    {
        private Context context = new Context();

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
                viewModel.PopulateSelectList(spRepo.GetAllSemesterPeriods());
            }
                 
            return View(viewModel);
        }
    }
}