using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BryantUniversity.Repo
{
    public class StudentMajorRepo
    {
        private Context _context;

        public StudentMajorRepo(Context context)
        {
            _context = context;
        }

        public StudentMajor GetById(int id)
        {
            return _context.StudentMajors
                .FirstOrDefault(c => c.Id == id);
        }

        public StudentMajor GetByStudentId(int id)
        {
            return _context
                        .StudentMajors
                        .Include(s => s.Major)
                        .Include(s => s.User)
                        .Where(s => s.UserId == id)
                        .FirstOrDefault();
        }
        public IList<StudentMajor> GetAllStudentMajors()
        {
            return _context.StudentMajors
                .Include(m => m.Major)
                .ToList();
        }

        public void Insert(StudentMajor studentMajors)
        {
            _context.StudentMajors.Add(studentMajors);
            _context.SaveChanges();
        }

        public void Update(StudentMajor studentMajors)
        {
            _context.StudentMajors.Attach(studentMajors);
            _context.Entry(studentMajors).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {

        }
    }
}