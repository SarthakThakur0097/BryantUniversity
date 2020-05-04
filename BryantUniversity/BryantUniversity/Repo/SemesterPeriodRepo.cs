using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Linq;

namespace BryantUniversity.Repo
{
    public class SemesterPeriodRepo
    {
        private Context _context;

        public SemesterPeriodRepo(Context context)
        {
            _context = context;
        }

        public IList<SemesterPeriod> GetAllSemesterPeriods()
        {
            return _context
                        .SemesterPeriods
                        .ToList();
        }

        public SemesterPeriod GetById(int id)
        {
            return _context
                        .SemesterPeriods
                        .SingleOrDefault(c => c.Id == id);
        }

        public void Insert(SemesterPeriod semesterPeriod)
        {
            _context
                .SemesterPeriods
                .Add(semesterPeriod);

            _context.SaveChanges();
        }

        public void Update(Role role)
        {
            _context.Roles.Attach(role);
            _context.Entry(role).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}