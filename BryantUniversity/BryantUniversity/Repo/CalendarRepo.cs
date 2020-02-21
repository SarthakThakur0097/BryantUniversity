using BryantUniversity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models.Repo
{
    public class CalendarRepo
    {
        private Context _context;

        public CalendarRepo(Context context)
        {
            _context = context;
        }

        public IList<SemesterDetails> GetAllCalendarEvents()
        {
            return _context.CalendarEvents.ToList();

        }

        public SemesterDetails GetById(int id)
        {
            return _context.CalendarEvents.SingleOrDefault(c => c.Id == id);
        }


        public void Update(SemesterDetails calendar)
        {
            _context.CalendarEvents.Attach(calendar);
            _context.Entry(calendar).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Insert(SemesterDetails calendar)
        {
            _context.CalendarEvents.Add(calendar);
            _context.SaveChanges();
        }

    }
}