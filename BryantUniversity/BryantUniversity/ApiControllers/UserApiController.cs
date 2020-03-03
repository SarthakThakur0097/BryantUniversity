﻿using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using System.Collections.Generic;
using System.Web.Http;

namespace BryantUniversity.ApiControllers
{
    [RoutePrefix("api/User")]
    [AllowAnonymous]
    public class UserApiController : ApiController
    {
        private Context context;

        public UserApiController()
        {
            context = new Context();
        }
        // GET: CalendarApi

        [Route("{roleId}")]
        [HttpPost]
        public IHttpActionResult ChangePeriod(int roleId)
        {
            using (context)
            {
                var userRepo = new UserRepo(context);
                IList<User> users = userRepo.GetUsersByRole(roleId);
                return Ok(users);
            }
            
        }
    }
}