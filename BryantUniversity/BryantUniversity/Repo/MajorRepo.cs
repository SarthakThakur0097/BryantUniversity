using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace BryantUniversity.Repo
{
    public class MajorRepo
    {
        private Context _context;

        public MajorRepo(Context context)
        {
            _context = context;
        }

        public Major GetById(int id)
        {
            return _context.Majors
                .SingleOrDefault(c => c.Id == id);
        }

        public IList<Major> GetAllMajors()
        {
            return _context.Majors
                .Include(m => m.Department)
                .ToList(); 
        }

        public IList<Major> GetAllMajorsByDepartment(int id)
        {
            return _context.Majors
                .Include(m => m.Department)
                .Where(m => m.DepartmentId == id)
                .ToList();
        }

        public void Insert(Major major)
        {
            _context.Majors.Add(major);
            _context.SaveChanges();
        }

        public void Update(Major major)
        {
            _context.Majors.Attach(major);
            _context.Entry(major).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {

        }
    }
}