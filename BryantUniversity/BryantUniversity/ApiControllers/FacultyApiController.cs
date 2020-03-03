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
    [RoutePrefix("api/Faculty")]
    [System.Web.Http.AllowAnonymous]
    public class FacultyApiController : ApiController
    {
        private Context context;

        public FacultyApiController()
        {
            context = new Context();
        }
        // GET: FacultyApi
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