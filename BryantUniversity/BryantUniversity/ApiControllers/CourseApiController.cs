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
    [RoutePrefix("api/Course")]
    [AllowAnonymous]
    public class CourseApiController : ApiController
    {
        // GET: CourseApi

        [Route("{teacherId}/course/{courseId}")]
        [HttpGet]
        public IHttpActionResult AssignTeacherToCourse(int teacherId, int courseId)
        {

            return Ok();
        }
    }
}