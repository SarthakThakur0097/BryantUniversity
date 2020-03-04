using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
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

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(int id)
        {
            using (context)
            {
                User student = new UserRepo(context).GetByEmail(User.Identity.Name);
                CourseSection courseSection = new CourseSectionRepo(context).GetCourseSectionById(id);
                Schedule schedule = new Schedule(student, courseSection);
                new ScheduleRepo(context).Insert(schedule);
                return RedirectToAction("Index");
            }
        }

    }
}