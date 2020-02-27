using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class SemesterPeriod
    {
        public int Id { get; set; }
        public string Period { get; set; }
        
        public List<CalendarEvent> SemesterDetails { get; set; }
        public SemesterPeriod(){}

        public SemesterPeriod(string period)
        {
            Period = period;
        }

    }
}