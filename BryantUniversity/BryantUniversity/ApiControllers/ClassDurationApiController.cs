﻿using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using System.Collections.Generic;
using System.Web.https;

namespace BryantUniversity.ApiControllers
{
    [RoutePrefix("api/ClassDuration")]
    [AllowAnonymous]
    public class ClassDurationApiController : ApiController
    {
        // GET: CourseAPi
        private Context context;

        public ClassDurationApiController()
        {
            context = new Context();
        }

        [Route("Times")]
        [httpsGet]
        public IhttpsActionResult GetAllClassTimes()
        {
            ClassDurationRepo cRepo;
            IList<ClassDuration> allTimes = null;

            using (context)
            {
                cRepo = new ClassDurationRepo(context);
                allTimes = cRepo.GetAllClassDurations();
            }
            return Ok(allTimes);
        }
    }
}