using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace BryantUniversity.Repo
{
    public class AdviserRepo
    {
        public Context _context;

        public AdviserRepo(Context context)
        {
            _context = context;
        }

        public IList<Advisor> GetAllAdvisedStudentsByAdviserId(int id)
        {
            return _context.Advisors
                .Include(b => b.Faculty)
                .Include(b => b.Student)
                .Where(b => b.FacultyId == id)
                .ToList();
        }

        public IList<Advisor> GetAllAdvisorsStudentId(int id)
        {
            return _context.Advisors
                .Include(b => b.Faculty)
                .Include(b => b.Student)
                .Where(b => b.StudentId == id)
                .ToList();
        }

        public IList<Advisor> GetAllAdvisors()
        {
            return _context.Advisors
                .Include(b => b.Faculty)
                .Include(b => b.Student)
                .ToList();
        }

        public Advisor GetById(int advisorId)
        {
            return _context.Advisors.FirstOrDefault(c => c.Id == advisorId);
        }


        public void Update(Advisor advisor)
        {
            _context.Advisors.Attach(advisor);
            _context.Entry(advisor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Insert(Advisor advisor)
        {
            _context.Advisors.Add(advisor);
            _context.SaveChanges();
        }

    }
}