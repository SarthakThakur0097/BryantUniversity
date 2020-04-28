using System.Collections.Generic;

namespace BryantUniversity.Models
{
    public class Registration
    {
        public Registration() { }

        public Registration(int userId, int courseSectionId)
        {
            UserId = userId;
            CourseSectionId = courseSectionId;
        }
        public Registration(User user, CourseSection courseSection)
        {
            User = user;
            CourseSection = courseSection;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseSectionId { get; set; }
        public CourseSection CourseSection { get; set; }
        public Grade Grades { get; set; }
    }
}