using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class FacultyHistory
    {
        public FacultyHistory(){}

        public FacultyHistory(int userId, int courseSectionId)
        {
            UserId = userId;
            CourseSectionId = courseSectionId;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseSectionId { get; set; }
        public CourseSection CourseSection { get; set; }
    }
}