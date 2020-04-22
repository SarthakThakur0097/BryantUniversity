using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
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

        [Route("Assign")]
        [HttpPost]
        public IHttpActionResult AssignTeacherToCourse([FromBody]CourseSection courseSection)
        { 
            bool test = ModelState.IsValid;
            CourseSectionRepo csRepo;
            CourseSection toInsert;
            using (context)
            {
                csRepo = new CourseSectionRepo(context);

                toInsert = new CourseSection(0, courseSection.CourseId, courseSection.RoomId, courseSection.UserId, courseSection.SemesterPeriodId);
                csRepo.Insert(toInsert);
            }
            return Json(new { redirectUrl = "/checkout/thank-you" });
        }
        //[Route("Assign/{courseSection}")]
        //[HttpPost]
        //public IHttpActionResult AssignTeacherToCourse([FromBody]JObject courseSection)
        //{
        //    CourseSectionRepo csRepo;
        //    //UserRepo userRepo;
        //    //CoursesRepo courseRepo;
        //    //RoomRepo roomRepo;
        //    //SemesterPeriodRepo semRepo;

        //    using (context)
        //    {
        //        csRepo = new CourseSectionRepo(context);
        //        //userRepo = new UserRepo(context);
        //        //courseRepo = new CoursesRepo(context);
        //        //roomRepo = new RoomRepo(context);
        //        //semRepo = new SemesterPeriodRepo(context);

        //        //Course course = courseRepo.GetById(courseId);
        //        //Room room = roomRepo.GetById(1);
        //        //User teacher = userRepo.GetById(teacherId);
        //        //SemesterPeriod semPeriod = semRepo.GetById(1);

        //        //CourseSection courseSection = new CourseSection(DateTime.Now, course, room, teacher, semPeriod);
        //        csRepo.Insert(courseSection);
        //    }
        //        return Json(new { redirectUrl = "/checkout/thank-you" });
        //}
    }
}