using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BryantUniversity.Models
{
    public class CourseSection
    {
        public CourseSection()
        {
            Schedules = new List<Schedule>();
        }

        public CourseSection(DateTime timeSlot, Course course, Room room, User professor, SemesterPeriod semesterPeriod):this()
        {
            TimeSlot = timeSlot;
            Course = course;
            Room = room;
            Professor = professor;
            SemesterPeriod = semesterPeriod;
            new DateTime();
        }

        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SectionNumber { get; set; }
        public DateTime TimeSlot { get; set; }
        public Course Course { get; set; }
        public Room Room { get; set; }
        public User Professor { get; set; }
        public SemesterPeriod SemesterPeriod { get; set; }
        public ClassPattern Pattern { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}