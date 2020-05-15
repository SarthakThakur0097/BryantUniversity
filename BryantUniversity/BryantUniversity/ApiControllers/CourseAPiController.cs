using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using System.Collections.Generic;
using System.Web.Http;

namespace BryantUniversity.ApiControllers
{
    [RoutePrefix("api/Calendar")]
    [AllowAnonymous]
    public class CourseApiController : ApiController
    {
        // GET: CourseAPi
        private Context context;

        public CourseApiController()
        {
            context = new Context();
        }

        [Route("Courses")]
        [HttpGet]
        public IHttpActionResult GetAllSemEvents()
        {
            CoursesRepo cRepo;
            IList<Course> allCourses = null;
            using (context)
            {
                cRepo = new CoursesRepo(context);
                //allCourses =
            }
            return Ok(allCourses);
        }
    }
}