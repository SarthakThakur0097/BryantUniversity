using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class SemesterDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public DateTime Date { get; set; }
        public string EventDescription { get; set; }

        public SemesterDetails() { }

        public SemesterDetails(DateTime date, string eventDescription)
        {
            Date = date;
            EventDescription = eventDescription;
        }

        public SemesterDetails(string name, string urlSlug, DateTime date, string eventDescription)
        {
            Name = name;
            UrlSlug = urlSlug;
            Date = date;
            EventDescription = eventDescription;
        }
    }
}