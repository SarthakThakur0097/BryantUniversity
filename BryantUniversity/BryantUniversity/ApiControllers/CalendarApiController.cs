using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace BryantUniversity.ApiControllers
{
    [RoutePrefix("api/Calendar")]
    [AllowAnonymous]
    public class CalendarApiController : ApiController
    {
        private Context context;

        public CalendarApiController()
        {
            context = new Context();
        }
        [Route("Periods")]
        [HttpGet]
        public IHttpActionResult GetAllSemEvents()
        {
            SemesterPeriodRepo sRepo;
            IList<SemesterPeriod> allPeriods;
            using (context)
            {
                sRepo = new SemesterPeriodRepo(context);
                allPeriods = sRepo.GetAllSemesterPeriods();
            }
            return Ok(allPeriods);
        }
        [Route("{periodId}")]
        [HttpPost]
        public IHttpActionResult ChangePeriod(int periodId)
        {
            CalendarRepo cRepo;
            IList<CalendarEvent> allEvents;
            using (context)
            {
                cRepo = new CalendarRepo(context);
                allEvents = cRepo.GetById(periodId);
            }
            return Ok(allEvents);
        }
    }
}