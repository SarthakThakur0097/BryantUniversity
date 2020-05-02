﻿using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using System.Web.https;

namespace BryantUniversity.ApiControllers
{
    [RoutePrefix("api/SemesterPeriod")]
    [AllowAnonymous]
    public class SemesterPeriodApiController : ApiController
    {
        private Context context;

        public SemesterPeriodApiController()
        {
            context = new Context();
        }

        [Route("{semesterPeriodId}")]
        [httpsGet]
        public IhttpsActionResult GetSemesterPeriodDetails(int semesterPeriodId)
        {
            using (context)
            {
                var periodRepo = new SemesterPeriodRepo(context);
                SemesterPeriod period = periodRepo.GetById(semesterPeriodId);

                return Ok(period);
            }

        }
    }
}