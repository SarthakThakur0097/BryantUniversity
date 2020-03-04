using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            return _context.Schedules
                .Include(s => s.User)
                .Include(s => s.CourseSection)
                .Include(s => s.CourseSection.Course)
                .Where(s => s.UserId == id).
                ToList();
        }
        //To Fix
        public void Insert(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
        }

    }
}