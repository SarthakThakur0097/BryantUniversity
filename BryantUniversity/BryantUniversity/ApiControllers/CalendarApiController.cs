﻿using BryantUniversity.Data;
using BryantUniversity.Models.Repo;
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
        //[EnableCors("*","*","*")]
        
        // GET: CalendarApi


        [Route("{periodId}")]
        [HttpPost]
        public IHttpActionResult ChangePeriod(int periodId)
        {
            CalendarRepo cRepo = new CalendarRepo(context);

            return Ok(cRepo.GetById(periodId));
        }
    }
}