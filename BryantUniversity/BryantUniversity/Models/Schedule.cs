﻿using System.Collections.Generic;

namespace BryantUniversity.Models
{
    public class Schedule
    {
        public Schedule() { }

        public Schedule(int userId, int courseSectionId)
        {
            UserId = userId;
            CourseSectionId = courseSectionId;
        }
        public Schedule(User user, CourseSection courseSection)
        {
            User = user;
            CourseSection = courseSection;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseSectionId { get; set; }
        public CourseSection CourseSection { get; set; }
    }
}