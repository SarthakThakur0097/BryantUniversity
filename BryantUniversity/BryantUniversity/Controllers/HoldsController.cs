using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using BryantUniversity.Security;
using BryantUniversity.ViewModels;
using System.Web.Mvc;

namespace BryantUniversity.ApiControllers
{
    [Authorize(Roles = "1")]
    public class HoldsController : Controller
    {
        private Context context;

        public CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }

        public HoldsController()
        {
            context = new Context();
        }

        // GET: Holds
        public ActionResult Index()
        {
            StudentHoldViewModel viewModel;
            StudentHoldRepo studentHoldRepo;
            UserRepo userRepo;

            using (context)
            {
                viewModel = new StudentHoldViewModel();
                studentHoldRepo = new StudentHoldRepo(context);
                userRepo = new UserRepo(context);
                viewModel.Users = userRepo.GetUsersByRole(4);

                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult Manage(int id)
        {
            StudentHoldViewModel viewModel = new StudentHoldViewModel();
            UserRepo userRepo;
            StudentHoldRepo studentHoldRepo;
            using (context)
            {
                studentHoldRepo = new StudentHoldRepo(context);
                userRepo = new UserRepo(context);

                viewModel.UserHolds = studentHoldRepo.GetAllStudentHoldsById(id);
                viewModel.ToDisplay = userRepo.GetById(id);

                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            HoldRepo hRepo;
            HoldViewModel viewModel = new HoldViewModel();
            using (context)
            {
                hRepo = new HoldRepo(context);
                viewModel.PopulateSelectList(hRepo.GetAllHolds());

            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(int id, HoldViewModel viewModel)
        {
            HoldRepo hRepo;
            StudentHoldRepo sRepo;

            using (context)
            {
                sRepo = new StudentHoldRepo(context);
                hRepo = new HoldRepo(context);

                sRepo.Insert(new StudentHold(id, viewModel.HoldId));
                viewModel.PopulateSelectList(hRepo.GetAllHolds());

            }

            return RedirectToAction("Index", "Holds");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            StudentHoldRepo sRepo;
            StudentHoldViewModel viewModel = new StudentHoldViewModel();

            using (context)
            {
                sRepo = new StudentHoldRepo(context);
                viewModel.HoldToDelete = sRepo.GetUserByStudentHoldId(id);
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(StudentHoldViewModel viewModel)
        {
            StudentHoldRepo hRepo;

            using (context)
            {
                hRepo = new StudentHoldRepo(context);
                hRepo.Delete(viewModel.HoldToDelete.UserId);
            }
                return View();
        }
    }
}