using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class StudentLevel
    {
        public StudentLevel(){ }

        public StudentLevel(int userId, CourseLevel courseLevel)
        {
            UserId = userId;
            CourseLevel = courseLevel;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseLevelId { get; set; }
        public CourseLevel CourseLevel { get; set; }

    }
}