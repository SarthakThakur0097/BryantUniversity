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

        public void Insert(Registration registration)
        {
            _context.Registrations.Add(registration);
            _context.SaveChanges();
        }

        public void Insert(Advisor advisor)
        {
            _context.Advisors.Add(advisor);
            _context.SaveChanges();
        }

        public Registration GetByStudentAndSectionId(int studentId, int sectionId)
        {
            return _context.Registrations
                .Include(r => r.CourseSection)
                .Include(r => r.User)
                .FirstOrDefault(r => r.UserId == studentId && r.CourseSectionId == sectionId);
        }


        public IList<Registration> GetRegistrationByUserId(int id)
        {
            return _context
                        .Registrations
                        .Include(s => s.User)
                        .Include(c => c.CourseSection)
                        .Include(c => c.CourseSection.Course)
                        .Include(c => c.CourseSection.ClassDays)
                        .Include(c => c.CourseSection.ClassDuration)
                        .Include(c => c.CourseSection.Professor)
                        .Include(c => c.CourseSection.Room.Building)
                        .Include(c => c.CourseSection.Room)
                        .Include(c => c.CourseSection.SemesterPeriod)
                        .Where(s => s.UserId == id)
                        .ToList();
        }

        public IList<Registration> GetRegistrationByUserIdAndPeriodId(int studentId, int periodId)
        {
            return _context.Registrations
                .Include(s => s.User)
                .Include(s => s.CourseSection.Room)
                .Include(s => s.CourseSection.Course)
                .Include(s => s.CourseSection.ClassDays)
                .Include(s => s.CourseSection.Professor)
                .Include(s => s.CourseSection.ClassDuration)
                .Include(s => s.CourseSection.Room.Building)
                .Include(s => s.CourseSection.Course.CourseLevel)
                .Include(c => c.CourseSection).Where(p => p.CourseSection.SemesterPeriodId == periodId)
                .Where(s => s.UserId == studentId).
                ToList();
        }

        public Registration GetById(int id)
        {
            return _context.Registrations.FirstOrDefault(r => r.Id == id);
        }

        public IList<Registration> GetRegistrationByUserAndCourseSection(int userId, int courseSectoinId)
        {
            return _context.Registrations
                .Include(u => u.User).Where(u => u.UserId == userId)
                .Include(c => c.CourseSection).Where(c => c.CourseSectionId == courseSectoinId)
                .ToList();
        }

        public Registration GetRegistrationByCourseSectionId(int id)
        {
            return _context.Registrations
                .Include(s => s.User)
                .Include(s => s.CourseSection)
                .Include(s => s.CourseSection.Course)
                .Include(s => s.CourseSection.Course.Department)
                .Include(s => s.CourseSection.Professor)
                .Include(s => s.CourseSection.SemesterPeriod)
                .Include(s => s.CourseSection.Room)
                .FirstOrDefault(s => s.CourseSectionId == id);
        }

        public IList<Registration> GetRegistrationsByCourseSectionId(int id)
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

        public void Delete(int id)
        {
            Registration toRemove = GetRegistrationByCourseSectionId(id);
            _context.Registrations.Remove(toRemove);
            _context.SaveChanges();
        }
    }
}