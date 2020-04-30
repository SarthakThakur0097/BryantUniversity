using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BryantUniversity.Repo
{
    public class DaysRepo
    {
        private Context _context;

        public DaysRepo(Context context)
        {
            _context = context;
        }

        public IList<Days> GetAllDays()
        {
            return _context.ClassDays.ToList();
        }

        public Days GetById(int id)
        {
            return _context.ClassDays.SingleOrDefault(c => c.Id == id);
        }

        public void Insert(Days day)
        {
            _context.ClassDays.Add(day);
            _context.SaveChanges();
        }

        public void Update(Days day)
        {
            _context.ClassDays.Attach(day);
            _context.Entry(day).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}