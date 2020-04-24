using System.ComponentModel.DataAnnotations;

namespace BryantUniversity.Models
{
    public class Course
    {
        public Course() { }

        public Course(int id, string courseTitle, string description, int credits, string level)
        {
            Id = id;
            CourseTitle = courseTitle;
            Description = description;
            Credits = credits;
            Level = level;
        }

        public Course(int id, string courseTitle, string description, int credits, string level, int departmentId)
        {
            Id = id;
            CourseTitle = courseTitle;
            Description = description;
            Credits = credits;
            Level = level;
            DepartmentId = departmentId;
        }

        public Course(int id, string courseTitle, string description, int credits, string level, Department department)
        {
            Id = id;
            CourseTitle = courseTitle;
            Description = description;
            Credits = credits;
            Level = level;
            Department = department;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string CourseTitle { get; set; }
        [Required] 
        public string Description { get; set; }
        public int Credits { get; set; }
        [Required]
        public string Level { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}