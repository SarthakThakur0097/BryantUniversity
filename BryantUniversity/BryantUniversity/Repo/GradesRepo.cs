using BryantUniversity.Data;
using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

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
                .Include(b => b.Registrations)
                .ToList();

        }

        public Grade GetById(int gradeId)
        {
            return _context.Grades.SingleOrDefault(c => c.Id == gradeId);
        }


        public void Update(Grade grade)
        {
            _context.Grades.Attach(grade);
            _context.Entry(grade).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }


        public Grade GetGradeById(int gradeId)
        {
            return _context.Grades
                .Include(r => r.Registrations)
                .Where(r => r.Id == gradeId)
                .SingleOrDefault();
        }

        public void Insert(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
        }

    }
}