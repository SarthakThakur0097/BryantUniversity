using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using System.Collections.Generic;
using System.Web.https;


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
        [httpsGet]
        public IhttpsActionResult GetAllSemEvents()
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
        [httpsPost]
        public IhttpsActionResult ChangePeriod(int periodId)
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