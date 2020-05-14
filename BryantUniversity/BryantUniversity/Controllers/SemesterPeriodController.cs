using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using BryantUniversity.ViewModels;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class SemesterPeriodController : Controller
    {
        public SemesterPeriodController()
        {
            context = new Context();
        }
        private Context context;
        // GET: SemesterPeriod
        public ActionResult Index()
        {
            SemesterPeriodRepo spRepo;
            SemesterPeriodIndexViewModel viewModel = new SemesterPeriodIndexViewModel();
            using (context)
            {
                spRepo = new SemesterPeriodRepo(context);
                viewModel.SemesterPeriods = spRepo.GetAllSemesterPeriods();
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int periodId)
        {
            SemesterPeriodRepo spRepo;
            SemesterPeriodEditViewModel viewModel = new SemesterPeriodEditViewModel();
            using (context)
            {
                spRepo = new SemesterPeriodRepo(context);
                SemesterPeriod toEdit = spRepo.GetById(periodId);

                viewModel.SemesterPeriodId = toEdit.Id;
                viewModel.StartDate = toEdit.StartDate;
                viewModel.EndDate = toEdit.EndDate;
                viewModel.StartEnrollmentDate = toEdit.StartEnrollmentDate;
                viewModel.EndEnrollmentDate = toEdit.EndEnrollmentDate;
                viewModel.StartGradeTime = toEdit.StartGradeTime;
                viewModel.EndGradeTime = toEdit.EndGradeTime;
            }
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult EditPeriod(int id, SemesterPeriodEditViewModel viewModel)
        {
            SemesterPeriodRepo spRepo;

            using (context)
            {
                spRepo = new SemesterPeriodRepo(context);
                SemesterPeriod current = spRepo.GetById(id);
                SemesterPeriod toEdit = new SemesterPeriod(id, current.Period, viewModel.StartDate, viewModel.EndDate, viewModel.StartEnrollmentDate, viewModel.EndEnrollmentDate, viewModel.StartGradeTime, viewModel.EndGradeTime);

                spRepo.Update(toEdit);
            }
            return RedirectToAction("Index", "SemesterPeriod");
        }
    }
}