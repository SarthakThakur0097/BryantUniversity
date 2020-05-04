using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BryantUniversity.Repo
{
    public class MinorRepo
    {
        private Context _context;

        public MinorRepo(Context context)
        {
            _context = context;
        }

        public Minor GetById(int id)
        {
            return _context
                        .Minors
                        .SingleOrDefault(c => c.Id == id);
        }

        public IList<Minor> GetAllMinors()
        {
            return _context
                        .Minors
                        .Include(m => m.Department)
                        .ToList();
        }

        public IList<Minor> GetAllMinorsByDepartment(int id)
        {
            return _context
                        .Minors
                        .Include(m => m.Department)
                        .Where(m => m.DepartmentId == id)
                        .ToList();
        }

        public void Insert(Minor minor)
        {
            _context.Minors.Add(minor);
            _context.SaveChanges();
        }

        public void Update(Minor minor)
        {
            _context.Minors.Attach(minor);
            _context.Entry(minor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {

        }
    }
}