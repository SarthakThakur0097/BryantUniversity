using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using BryantUniversity.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    [Authorize(Roles = "2,1")]
    public class GradesController : Controller
    {
        private Context context;

        public GradesController()
        {
            context = new Context();
        }
        // GET: Grades
        [HttpGet]
        public ActionResult AssignGrade(int id, int cid)
        {
            AssignGradeViewModel viewModel = new AssignGradeViewModel();
            UserRepo uRepo;
            LetterGradesRepo lgRepo;
            CourseSectionRepo csRepo;

            using (context)
            {
                csRepo = new CourseSectionRepo(context);
                lgRepo = new LetterGradesRepo(context);
                uRepo = new UserRepo(context);
                User toAssign = uRepo.GetById(id);
                csRepo.GetCourseSectionById(cid);
                viewModel.Section = csRepo.GetCourseSectionById(cid);
                viewModel.PopulateSelectList(lgRepo.GetAllLetterGrades());
                viewModel.Student = toAssign;
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AssignGrade(int id, int cid, AssignGradeViewModel viewModel)
        {

            UserRepo uRepo;
            RegistrationRepo rRepo;
            GradesRepo gRepo;

            using (context)
            {
                rRepo = new RegistrationRepo(context);
                gRepo = new GradesRepo(context);

                rRepo = new RegistrationRepo(context);

                Registration toAssignGrade = rRepo.GetByStudentAndSectionId(id, cid);
                Grade assigned = new Grade(viewModel.LetterGradeId, toAssignGrade.Id);
                gRepo.Insert(assigned);
            }
            return RedirectToAction("Teaching", "Faculty");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            GradesRepo gRepo;

            using (context)
            {
                gRepo = new GradesRepo(context);
                Grade grade = gRepo.GetById(id); 

            }
            return View();
        }
    }
}