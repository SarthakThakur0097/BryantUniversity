using System;
using System.Collections.Generic;

namespace BryantUniversity.Models
{
    public class SemesterPeriod
    {
        public SemesterPeriod() { }

        public SemesterPeriod(Period period)
        {
            Period = period;
        }

        public SemesterPeriod(Period period, DateTime startDate, DateTime endDate)
        {
            Period = period;
            StartDate = startDate;
            EndDate = endDate; 
        }

        public SemesterPeriod(Period period, DateTime startDate, DateTime endDate, DateTime startEnrollmentDate, DateTime endEnrollmentDate)
        {
            Period = period;
            StartDate = startDate;
            EndDate = endDate;
            StartEnrollmentDate = startEnrollmentDate;
            EndEnrollmentDate = EndEnrollmentDate;
        }
        //public SemesterPeriod(Period period, DateTime startDate, DateTime endDate)
        //{
        //    Period = period;
        //    StartDate = startDate;
        //    EndDate = endDate;
        //}

        public int Id { get; set; }
        public Period Period { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? StartEnrollmentDate { get; set; }
        public DateTime? EndEnrollmentDate { get; set; }
        public List<CalendarEvent> SemesterDetails { get; set; }
    }
}