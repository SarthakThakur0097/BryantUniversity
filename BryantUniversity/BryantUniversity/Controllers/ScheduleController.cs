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
    public class ScheduleController : Controller
    {
        private Context context;

        public ScheduleController()
        {
            context = new Context();
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