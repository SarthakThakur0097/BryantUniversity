using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class Attendance
    {
        public Attendance(){}

        public Attendance(int userId, int courseId, DateTime dateOfClass, bool isPresent)
        {
            UserId = userId;
            CourseSectionId = courseId;
            DateOfClass = dateOfClass;
            IsPresent = isPresent;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseSectionId { get; set; }
        public CourseSection Course { get; set; }
        public DateTime DateOfClass { get; set; }
        public bool IsPresent { get; set; }
    }
}