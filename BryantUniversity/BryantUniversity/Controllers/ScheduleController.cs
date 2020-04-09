using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using BryantUniversity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class ScheduleController : Controller
    {
        private Context context;

        public CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }

        public ScheduleController()
        {
            context = new Context();
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            CourseSectionRepo csRepo;
            ScheduleRepo sRepo;
            CourseSection toAdd;
            using (context)
            {
                csRepo = new CourseSectionRepo(context);
                sRepo = new ScheduleRepo(context);

                toAdd = csRepo.GetCourseSectionById(id);
                Schedule userCourseSection = new Schedule(CustomUser.User.Id, toAdd.Id);
                sRepo.Insert(userCourseSection);
            }
            return View("Index");
        }
        // GET: Schedule
        [HttpGet]
        public ActionResult Index()
        {
            using (context)
            {
                User currUser = new UserRepo(context).GetByEmail(User.Identity.Name);
                IList<Schedule> schedules = new ScheduleRepo(context).GetScheduleByUserId(currUser.Id);
                return View(schedules);
            }
         
        }
    }
}