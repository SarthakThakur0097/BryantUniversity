using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Data.Entity;



namespace BryantUniversity.Repo
{
    public class ScheduleRepo
    {
        private Context _context;

        public ScheduleRepo(Context context)
        {
            _context = context;
        }

        public IList<Schedule> GetScheduleByUserId(int id)
        {
            _context.Schedules.Include(s => s.User).Include(s => s.CourseSection).
        }
        public void Insert(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
        }

    }
}