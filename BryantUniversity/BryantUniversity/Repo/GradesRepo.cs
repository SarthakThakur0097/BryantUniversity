using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BryantUniversity.Repo
{
    public class GradesRepo
    {
        public Context _context;

        public GradesRepo(Context context)
        {
            _context = context;
        }

        public IList<Grade> GetAllGrades()
        {
            return _context.Grades
                .Include(u => u.Registration)
                .ToList();

        }

        public Grade GetById(int gradeId)
        {
            return _context.Grades.FirstOrDefault(c => c.Id == gradeId);
        }

        public Grade GetGradeByRegistrationId(int rId)
        {
            return _context.Grades
                .Include(u => u.Registration.CourseSection.Course)
                .Include(u => u.Registration.CourseSection.Professor)
                .Include(u => u.Registration.CourseSection.Room.Building)
                .Where(c => c.Registration.Id == rId)
                .FirstOrDefault();
        }
        public bool ContainsRegistration(int id)
        {
            return _context.Grades
                    .Any(e => e.RegistrationId == id);
        }
        public void Update(Grade grade)
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    _context.Grades.Attach(grade);
                    _context.Entry(grade).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.Property("LetterGradeId").CurrentValue);
                }
            } while (saveFailed);
        }

        public IList<Grade> GetGradesByUserAndSemesterPeriodId(int userId, int spId)
        {
            return _context.Grades
                .Include(u => u.LetterGrade)
                .Include(u => u.Registration.CourseSection.Course).Where(s => s.Registration.CourseSection.SemesterPeriod.Id == spId)
                .Include(u => u.Registration.CourseSection.Professor).Where(s => s.Registration.CourseSection.SemesterPeriod.Id == spId)
                .Include(u => u.Registration.CourseSection.Room.Building).Where(s => s.Registration.CourseSection.SemesterPeriod.Id == spId)
                .Where(c => c.Registration.UserId == userId)
                .ToList();
        }

        public IList<Grade> GetAllGradesByUserId(int userId)
        {
            return _context.Grades
                .Include(u => u.Registration.User)
                .Include(u => u.Registration.CourseSection.Course)
                .Include(u => u.Registration.CourseSection.Course.CourseLevel)
                .Include(u => u.Registration.CourseSection.ClassDuration)
                .Include(u => u.Registration.CourseSection.Professor)
                .Include(u => u.LetterGrade)
                .Include(u => u.Registration.CourseSection.ClassDays)
                .Include(u => u.Registration.CourseSection.SemesterPeriod)
                .Include(u => u.Registration.CourseSection.Room.Building)
                .Where(c => c.Registration.UserId == userId)
                .ToList();
        }


        public void Insert(Grade grade)
        {
            _context.Grades.Add(grade);

            _context.SaveChanges();
        }

    }
}