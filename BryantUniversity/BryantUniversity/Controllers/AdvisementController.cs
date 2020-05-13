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

        public ActionResult Index()
        {
            AdvisorViewModel viewModel = new AdvisorViewModel();
            AdviserRepo aRepo;
            using (context)
            {
                aRepo = new AdviserRepo(context);
                viewModel.AllAdvisements = aRepo.GetAllAdvisors();
               
                return View(viewModel);
            }
        }

        
    }
}