using System.Collections.Generic;
namespace BryantUniversity.Models
{
    public class Registration
    {
        public Registration()
        {
            Grades = new List<Grade>();
        }
        public Registration(int userId, int courseSectionId) : this()
        {
            UserId = userId;
            CourseSectionId = courseSectionId;
        }
        public Registration(User user, CourseSection courseSection) : this()
        {
            User = user;
            CourseSection = courseSection;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseSectionId { get; set; }
        public CourseSection CourseSection { get; set; }
        public List<Grade> Grades { get; set; }
    }
}