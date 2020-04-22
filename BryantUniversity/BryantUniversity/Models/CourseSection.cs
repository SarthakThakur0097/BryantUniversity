﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BryantUniversity.Models
{
    public class CourseSection
    {
        public CourseSection()
        {
            Schedules = new List<Schedule>();
        }

        public CourseSection(int courseId, int roomId, int professorId, int semesterPeriodId) : this()
        {
            CourseId = courseId;
            RoomId = roomId;
            UserId = professorId;
            //TimeSlot = timeSlot;
            SemesterPeriodId = semesterPeriodId;
            new DateTime();
        }

        public CourseSection(int id, int courseId, int roomId, int professorId, int semesterPeriodId) : this()
        {
            Id = id;
            CourseId = courseId;
            RoomId = roomId;
            UserId = professorId;
            //TimeSlot = timeSlot;
            SemesterPeriodId = semesterPeriodId;
            new DateTime();
        }


        public CourseSection(/*DateTime timeSlot,*/ Course course, Room room, User professor, SemesterPeriod semesterPeriod):this()
        {
            //TimeSlot = timeSlot;
            Course = course;
            Room = room;
            Professor = professor;
            SemesterPeriod = semesterPeriod;   
        }

        [Key]
        public int Id { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SectionNumber { get; set; }
        //public DateTime TimeSlot { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int UserId { get; set; }
        public User Professor { get; set; }
        public int SemesterPeriodId { get; set; }
        public SemesterPeriod SemesterPeriod { get; set; }
        public ClassPattern Pattern { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}