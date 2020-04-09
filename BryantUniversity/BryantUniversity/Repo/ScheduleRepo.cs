using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BryantUniversity.Repo
{
    public class ScheduleRepo
    {
        private Context _context;

        public ScheduleRepo(Context context)
        {
            _context = context;
        }

        public IList<Schedule> GetScheduleByUserId(int id)
        {
            return _context.Schedules
                .Include(s => s.User)
                .Include(s => s.CourseSection)
                .Include(s => s.CourseSection.Course)
                .Include(s => s.CourseSection.Course.Department)
                .Include(s => s.CourseSection.Professor)
                .Include(s => s.CourseSection.SemesterPeriod)
                .Include(s => s.CourseSection.Room)
                .Where(s => s.UserId == id).
                ToList();
        }

        public IList<Schedule> GetScheduleByCourseSectionId(int id)
        {
            return _context.Schedules
                .Include(s => s.User)
                .Include(s => s.CourseSection)
                .Include(s => s.CourseSection.Course)
                .Include(s => s.CourseSection.Course.Department)
                .Include(s => s.CourseSection.Professor)
                .Include(s => s.CourseSection.SemesterPeriod)
                .Include(s => s.CourseSection.Room)
                .Where(s => s.CourseSectionId == id).
                ToList();
        }

        //public Schedule GetScheduleByUserAndCourseSectionId(int studentId, int courseSectionId)
        //{
        //    return _context.Schedules
        //        .Include(s => s.User)
        //        .Include(s => s.CourseSection)
        //        .Include(s => s.CourseSection.Course)
        //        .Where(s => s.UserId == studentId && s.CourseSectionId == courseSectionId)
        //        .SingleOrDefault();   
        //}

        public void Insert(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
        }

    }
}