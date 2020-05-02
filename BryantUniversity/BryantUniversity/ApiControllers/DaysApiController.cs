using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using System.Collections.Generic;
using System.Web.Http;

namespace BryantUniversity.ApiControllers
{
    [RoutePrefix("api/Days")]
    [AllowAnonymous]
    public class DaysApiController : ApiController
    {
        private Context context;

        public DaysApiController()
        {
            context = new Context();
        }

        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetAllDays()
        {
            DaysRepo dRepo;
            IList<Days> allDays = null;
            using (context)
            {
                dRepo = new DaysRepo(context);
                allDays = dRepo.GetAllDays();
            }
            return Ok(allDays);
        }
    }
}