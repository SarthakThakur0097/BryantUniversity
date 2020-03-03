using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public IHttpActionResult ChangeUser(int roleId)
        {
            using (context)
            {
                var userRepo = new UserRepo(context);
                IList<User> users = userRepo.GetUsersByRole(roleId);
                return Ok(users);
            }
            
        }

        [Route("AllFaculty")]
        [HttpPost]
        public IHttpActionResult GetAllFaculty()
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