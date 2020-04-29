﻿using BryantUniversity.Data;
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
                .Include(u => u.Registration)
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


        public IList<Grade> GetGradesByUserId(int userId, int spId)
        {
            return _context.Grades
                .Include(u => u.Registration.CourseSection.SemesterPeriod).Where(s => s.Registration.CourseSection.SemesterPeriod.Id == spId)
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