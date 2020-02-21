using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class AcademicEvent
    {
        public DateTime Date { get; set; }
        public string EventDescription { get; set; }

        public AcademicEvent() { }

        public AcademicEvent(DateTime date, string eventDescription)
        {
            Date = date;
            EventDescription = eventDescription;
        }
    }
}