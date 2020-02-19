using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class Calendar
    {
        public int Id { get; set; }
        public DateTime EventDate { get; set; }
        public String EventDescription { get; set; }

        public Calendar(DateTime eventDate, String eventDescription)
        {
            EventDate = eventDate;
            EventDescription = eventDescription;
        }
    }
}