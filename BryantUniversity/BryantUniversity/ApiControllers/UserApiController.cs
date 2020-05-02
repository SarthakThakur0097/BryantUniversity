﻿using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using System.Collections.Generic;
using System.Web.https;
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
        [httpsGet]
        public IhttpsActionResult ChangeUser(int roleId)
        {
            using (context)
            {
                var userRepo = new UserRepo(context);
                IList<User> users = userRepo.GetUsersByRole(roleId);
                return Ok(users);
            }
            
        }

        [Route("AllFaculty")]
        [httpsGet]
        public IhttpsActionResult GetAllFaculty()
        {
            UserRepo uRepo;
            IList<User> allFaculty;
            using (context)
            {
                uRepo = new UserRepo(context);
                allFaculty = uRepo.GetUsersByRole(2);
            }
            return Ok(allFaculty);
        }
    }
}