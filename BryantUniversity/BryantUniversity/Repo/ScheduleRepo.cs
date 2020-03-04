using BryantUniversity.Data;
using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Repo
{
    public class ScheduleRepo
    {
        private Context _context;

        public ScheduleRepo(Context context)
        {
            _context = context;
        }

        public void Insert(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
        }

    }
}