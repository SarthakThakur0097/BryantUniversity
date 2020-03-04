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
    [RoutePrefix("api/Coursesection")]
    [AllowAnonymous]
    public class CourseSectionApiController : ApiController
    {
        // GET: CourseApi
        private Context context;

        public CourseSectionApiController()
        {
            context = new Context();
        }

        [Route("{teacherId}/course/{courseId}")]
        [HttpPost]
        public IHttpActionResult AssignTeacherToCourse(int teacherId, int courseId)
        {
            CourseSectionRepo csRepo;
            UserRepo userRepo;
            CoursesRepo courseRepo;
            using (context)
            {
                csRepo = new CourseSectionRepo(context);
                userRepo = 
                
            }
                return Ok();
        }
    }
}