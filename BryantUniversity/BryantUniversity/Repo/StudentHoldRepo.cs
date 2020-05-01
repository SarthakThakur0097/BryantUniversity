using BryantUniversity.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using BryantUniversity.Models;

namespace BryantUniversity.Repo
{
    public class StudentHoldRepo
    {
        private Context _context;

        public StudentHoldRepo(Context context)
        {
            _context = context;
        }

        public IList<StudentHold> GetAllStudentHolds()
        {
            return _context.StudentHolds
                            .Include(s => s.User)
                            .ToList();
        }

        public IList<StudentHold> GetAllStudentHoldsById(int id)
        {
            return _context.StudentHolds
                            .Include(s => s.User)
                            .Include(h => h.Hold)
                            .Where(c => c.UserId == id).ToList();
        }

        public StudentHold GetById(int id)
        {
            return _context.StudentHolds.SingleOrDefault(c => c.Id == id);
        }


        public void Insert(StudentHold studenthold)
        {
            _context.StudentHolds.Add(studenthold);
            _context.SaveChanges();
        }

        public void Update(StudentHold studenthold)
        {
            _context.StudentHolds.Attach(studenthold);
            _context.Entry(studenthold).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}