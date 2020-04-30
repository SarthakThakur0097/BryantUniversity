using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BryantUniversity.Repo
{
    public class RegistrationRepo
    {
        private Context _context;

        public RegistrationRepo(Context context)
        {
            _context = context;
        }

        public IList<Registration> GetRegistrationByUserId(int id)
        {
            return _context.Registrations
                .Include(s => s.User)
                .Include(c => c.CourseSection)
                .Where(s => s.UserId == id).
                ToList();
        }

        public Registration GetById(int id)
        {
            return _context.Registrations.SingleOrDefault(r => r.Id == id);
        }

        public IList<Registration> GetRegistrationByUserAndCourseSection(int userId, int courseSectoinId)
        {
            return _context.Registrations
                .Include(u => u.User).Where(u => u.UserId == userId)
                .Include(c => c.CourseSection).Where(c => c.CourseSectionId == courseSectoinId)
                .ToList();
        }

        public IList<Registration> GetRegistrationByCourseSectionId(int id)
        {
            return _context.Registrations
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

        public IList<Registration> GetRegistrationByUserId(User student)
        {
            return _context.Registrations
                .Include(s => s.User)
                .Include(s => s.CourseSection)
                .Include(s => s.CourseSection.Course)
                .Include(s => s.CourseSection.Course.Department)
                .Include(s => s.CourseSection.Professor)
                .Include(s => s.CourseSection.SemesterPeriod)
                .Include(s => s.CourseSection.Room)
                .Where(s => s.UserId == student.Id).
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

        public void Insert(Registration registration)
        {
            _context.Registrations.Add(registration);
            _context.SaveChanges();
        }

    }
}