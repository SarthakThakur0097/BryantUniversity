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
            RoomRepo roomRepo;
            SemesterPeriodRepo semRepo;

            using (context)
            {
                csRepo = new CourseSectionRepo(context);
                userRepo = new UserRepo(context);
                courseRepo = new CoursesRepo(context);
                roomRepo = new RoomRepo(context);
                semRepo = new SemesterPeriodRepo(context);

                Course course = courseRepo.GetById(courseId);
                Room room = roomRepo.GetById(1);
                User teacher = userRepo.GetById(teacherId);
                SemesterPeriod semPeriod = semRepo.GetById(1);

                CourseSection courseSection = new CourseSection(DateTime.Now, course, room, teacher, semPeriod);
                csRepo.Insert(courseSection);
            }
                return Ok();
        }
    }
}