using System;
using System.Collections.Generic;

namespace BryantUniversity.Models
{
    public class CourseSection
    {
        public CourseSection()
        {
            Schedules = new List<Registration>();
        }

        public CourseSection(int courseId, int roomId, int professorId, int semesterPeriodId) : this()
        {
            CourseId = courseId;
            RoomId = roomId;
            UserId = professorId;
            SemesterPeriodId = semesterPeriodId;
            new DateTime();
        }


        public CourseSection(int id, int courseId, int roomId, int professorId, int semesterPeriodId) : this()
        {
            Id = id;
            CourseId = courseId;
            RoomId = roomId;
            UserId = professorId;
            SemesterPeriodId = semesterPeriodId;
            new DateTime();
        }

        public CourseSection(int courseId, int roomId, int professorId, int classDaysId, int classDurationId, int semesterPeriodId) : this()
        {
            CourseId = courseId;
            RoomId = roomId;
            UserId = professorId;

            ClassDaysId = classDaysId;
            ClassDurationId = classDurationId;
            SemesterPeriodId = semesterPeriodId;
            new DateTime();
        }

        public int Id { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int UserId { get; set; }
        public User Professor { get; set; }

        public int ClassDaysId { get; set; }
        public Days ClassDays { get; set; }

        public int ClassDurationId { get; set; }
        public ClassDuration ClassDuration { get; set; }

        public int SemesterPeriodId { get; set; }
        public SemesterPeriod SemesterPeriod { get; set; }

        public List<Registration> Schedules { get; set; }
    }
}