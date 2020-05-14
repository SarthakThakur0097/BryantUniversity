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

        public SemesterPeriod(int id, Period period, DateTime startDate, DateTime endDate, DateTime startEnrollmentDate, DateTime endEnrollmentDate, DateTime startGradeTime, DateTime endGradeTime)
        {
            Id = id;
            Period = period;
            StartDate = startDate;
            EndDate = endDate;
            StartEnrollmentDate = startEnrollmentDate;
            EndEnrollmentDate = EndEnrollmentDate;
            StartGradeTime = startGradeTime;
            EndGradeTime = endGradeTime;
        }

        public SemesterPeriod(Period period, DateTime startDate, DateTime endDate, DateTime startEnrollmentDate, DateTime endEnrollmentDate, DateTime startGradeTime, DateTime endGradeTime)
        {
            Period = period;
            StartDate = startDate;
            EndDate = endDate;
            StartEnrollmentDate = startEnrollmentDate;
            EndEnrollmentDate = EndEnrollmentDate;
            StartGradeTime = startGradeTime;
            EndGradeTime = endGradeTime;
        }

        public int Id { get; set; }
        public Period Period { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartEnrollmentDate { get; set; }
        public DateTime EndEnrollmentDate { get; set; }
        public DateTime StartGradeTime { get; set; }
        public DateTime EndGradeTime { get; set; }
        public List<CalendarEvent> SemesterDetails { get; set; }
    }
}