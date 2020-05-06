using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using BryantUniversity.Security;
using BryantUniversity.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class TranscriptController : Controller
    {
        private Context context = new Context();

        public CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }
        // GET: Transcript
        [HttpGet]
        public ActionResult Index()
        {
            TranscriptViewModel viewModel = new TranscriptViewModel();
            SemesterPeriodRepo spRepo;
            using (context)
            {
                spRepo = new SemesterPeriodRepo(context);
                viewModel.PopulateSelectList(spRepo.GetAllSemesterPeriods());
            }
            return View(viewModel);
        }

    }
}