using BryantUniversity.Data;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using BryantUniversity.Security;
using BryantUniversity.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace BryantUniversity.Controllers
{
    public class AdvisementController : Controller
    {
        private Context context;

        public AdvisementController()
        {
            context = new Context();
        }

        [HttpGet]
        public ActionResult Index()
        {
            AdviserRepo aRepo;
            using (context)
            {
                UserRepo uRepo = new UserRepo(context);
                AdvisorViewModel viewModel = new AdvisorViewModel();
                aRepo = new AdviserRepo(context);
                viewModel.AllFaculty = uRepo.GetUsersByRole(2);

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Advisees(int id)
        {
            AdviserRepo aRepo;
            using (context)
            {
                UserRepo uRepo = new UserRepo(context);
                AdvisorViewModel viewModel = new AdvisorViewModel();
                aRepo = new AdviserRepo(context);

                viewModel.AllAdvisees = aRepo.GetAllAdviseesFromAdvisorId(id);
                return View(viewModel);
            }
        }
    }
}