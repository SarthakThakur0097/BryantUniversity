using System;
using System.Collections.Generic;

namespace BryantUniversity.Models
{
    public class CourseSection
    {
        public CourseSection()
        {
            Schedules = new List<Schedule>();
        }

        public CourseSection(DateTime timeSlot, int sectionNumber, Course course, Room room, User professor, SemesterPeriod semesterPeriod) : this()
        {
            TimeSlot = timeSlot;
            SectionNumber = sectionNumber;
            Course = course;
            Room = room;
            Professor = professor;
            SemesterPeriod = semesterPeriod;
        }

        public int Id { get; set; }
        public int SectionNumber { get; set; }
        public DateTime TimeSlot { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int UserId { get; set; }
        public User Professor { get; set; }
        public int SemesterPeriodId { get; set; }
        public SemesterPeriod SemesterPeriod { get; set; }

        public List<Schedule> Schedules { get; set; }
    }
}