using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using BryantUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class CourseSectionController : Controller
    {
        private Context context;

        public CourseSectionController()
        {
            context = new Context();
        }

        [HttpGet]
        public ActionResult Index(int Id, int semesterPeriodId)
        {
            CourseSectionRepo csRepo;
            IList<CourseSection> courseSections; 
            using (context)
            {
                csRepo = new CourseSectionRepo(context);

                courseSections = csRepo.GetCourseSectionsByCourseIdAndSemesterPeriodId(Id, semesterPeriodId);
            }

            return View("Index", courseSections);
        }
    }
}