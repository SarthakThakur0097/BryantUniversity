using BryantUniversity.Data;
using System.Collections.Generic;
using System.Linq;

namespace BryantUniversity.Models.Repo
{
    public class CalendarRepo
    {
        private Context _context;

        public CalendarRepo(Context context)
        {
            _context = context;
        }

        public IList<CalendarEvent> GetAllCalendarEvents()
        {
            return _context.CalendarEvents.ToList();

        }

        public IList<CalendarEvent> GetById(int periodId)
        {
            return _context.CalendarEvents
                .Where(c => c.SemPeriod.Id == periodId).ToList();
                //FirstOrDefault(c => c.Id == id);
        }


        public void Update(CalendarEvent semesterEvent)
        {
            _context.CalendarEvents.Attach(semesterEvent);
            _context.Entry(semesterEvent).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Insert(CalendarEvent semesterEvent)
        {
            _context.CalendarEvents.Add(semesterEvent);
            _context.SaveChanges();
        }

    }
}