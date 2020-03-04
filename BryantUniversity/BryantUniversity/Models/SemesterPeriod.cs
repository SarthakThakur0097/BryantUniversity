using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class SemesterPeriod
    {
        public SemesterPeriod() { }

        public SemesterPeriod(Period period)
        {
            Period = period;
        }

        public int Id { get; set; }
        public Period Period { get; set; }
        
        public List<CalendarEvent> SemesterDetails { get; set; }
    }
}