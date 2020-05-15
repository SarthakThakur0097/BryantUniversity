using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace BryantUniversity.ApiControllers
{
    [RoutePrefix("api/Attendance")]
    [AllowAnonymous]
    public class AttendanceApiController : ApiController
    {
        // GET: CourseApi
        private Context context;

        public AttendanceApiController()
        {
            context = new Context();
        }

        [Route("{month}/day/{day}/year/{year}/section/{sectionId}/student/{studentId}/present/{present}")]
        [HttpPost]
        public IHttpActionResult AddAttendance(int month, int day, int year, int sectionId, int studentId, bool present)
        {
            AttendanceRepo aRepo;
            Attendance studentAttendance;
            DateTime date = new DateTime(year,month,day);
            
            using (context)
            {
                aRepo = new AttendanceRepo(context);
                studentAttendance = new Attendance(sectionId, date, present);

                aRepo.Insert(studentAttendance);
                return Json(new { redirectUrl = "/Home/Index", error = "" });
            }
        }

        [Route("Assign")]
        [HttpPost]
        public IHttpActionResult AssignTeacherToCourse([FromBody]CourseSection courseSection)
        {
            bool test = ModelState.IsValid;
            CourseSectionRepo csRepo;
            RoomRepo rRepo;
            CourseSection toInsert;
            using (context)
            {
                csRepo = new CourseSectionRepo(context);
                rRepo = new RoomRepo(context);
                IList<CourseSection> currentlyTeaching = csRepo.GetCourseSectionByUserId(courseSection.UserId);
                IList<CourseSection> allCourseSections = csRepo.GetAllCourseSections();

                if (allCourseSections.Count >= 1)
                {
                    foreach (CourseSection teaching in allCourseSections)
                    {
                        if (teaching.Room.Id == courseSection.RoomId && teaching.ClassDaysId == courseSection.ClassDaysId && teaching.SemesterPeriodId == courseSection.SemesterPeriodId)
                        {
                            return Json(new { redirectUrl = "Home/Index", error = "This room is already assigned during this time period" });

                        }
                        if (teaching.ClassDays == courseSection.ClassDays && teaching.Id == courseSection.UserId && teaching.SemesterPeriodId == courseSection.SemesterPeriodId)
                        {
                            return Json(new { redirectUrl = "Home/Index", error = "This teacher is already teaching another course which would conflict with this one" });
                        }
                    }
                }
                toInsert = new CourseSection(courseSection.CourseId, courseSection.RoomId, courseSection.UserId, courseSection.ClassDaysId, courseSection.ClassDurationId, courseSection.SemesterPeriodId);
                csRepo.Insert(toInsert);
            }
            return Json(new { redirectUrl = "/Courses/Index", error = "" });
        }
    }
}