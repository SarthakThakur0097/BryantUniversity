using BryantUniversity.Data;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using BryantUniversity.Security;
using BryantUniversity.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace BryantUniversity.Controllers
{
    public class MajorsController : Controller
    {
        private Context context;

        public MajorsController()
        {
            context = new Context();
        }

        public ActionResult Index(int id)
        {
            MajorRequirementsViewModel viewModel = new MajorRequirementsViewModel();
            MajorRequirmentsRepo mRepo;
            using (context)
            {
                mRepo = new MajorRequirmentsRepo(context);
                viewModel.Requirements = mRepo.GetAllMajorRequirementsByMajor(id);

                return View(viewModel);
            }
        }
    }
}