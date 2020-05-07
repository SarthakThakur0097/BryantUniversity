using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BryantUniversity.Repo
{
    public class HoldRepo
    {
        private Context _context;

        public HoldRepo(Context context)
        {
            _context = context;
        }

        public IList<Hold> GetAllHolds()
        {
            return _context.Holds
                .Include(u => u.StudentHolds)
                .ToList();
        }

        public Hold GetById(int id)
        {
            return _context.Holds
                .FirstOrDefault(c => c.Id == id);
        }

        public IList<Hold> GetUsersByRole(int holdId)
        {
            IList<Hold> holds = _context.Holds
                .Include(u => u.StudentHolds)
                .Where(u => u.StudentHolds.Any(r => r.HoldId == holdId))
                .ToList();
            _context.SaveChanges();

            return holds;
        }

        public void Insert(Hold hold)
        {
            _context.Holds.Add(hold);
            _context.SaveChanges();
        }

        public void Update(Hold hold)
        {
            _context.Holds.Attach(hold);
            _context.Entry(hold).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            
        }
    }
}