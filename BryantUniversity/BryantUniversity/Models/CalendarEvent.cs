using BryantUniversity.Data;
using BryantUniversity.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class CalendarEvent
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public DateTime Date { get; set; }
        public string EventDescription { get; set; }
        public SemesterPeriod SemPeriod { get; set; }
        public List<SemesterPeriod> SemesterDetails { get; set; }
        public IList<SemesterPeriod> SemesterPeriods { get; set; }

        public CalendarEvent() { }

        public CalendarEvent(DateTime date, string eventDescription, SemesterPeriod semPeriod)
        {
            Date = date;
            EventDescription = eventDescription;
            SemPeriod = semPeriod; 
        }

        public CalendarEvent(string name, string urlSlug, DateTime date, string eventDescription)
        {
            Name = name;
            UrlSlug = urlSlug;
            Date = date;
            EventDescription = eventDescription;
        }
    }
}