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
        public ActionResult Assign(int id, int rId)
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
                csRepo.GetCourseSectionById(rId);
                viewModel.Section = csRepo.GetCourseSectionById(rId);
                viewModel.PopulateSelectList(lgRepo.GetAllLetterGrades());
                viewModel.Student = toAssign;
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Assign(int rId, AssignGradeViewModel viewModel)
        {

            UserRepo uRepo;
            RegistrationRepo rRepo;
            GradesRepo gRepo;

            using (context)
            {
                rRepo = new RegistrationRepo(context);
                gRepo = new GradesRepo(context);

                rRepo = new RegistrationRepo(context);

                Registration toAssignGrade = rRepo.GetByStudentAndSectionId(viewModel.Student.Id, viewModel.Section.Id);
                Grade assigned = new Grade(viewModel.LetterGradeId, toAssignGrade.Id);
                gRepo.Insert(assigned);
            }
            return View();
        }
    }
}