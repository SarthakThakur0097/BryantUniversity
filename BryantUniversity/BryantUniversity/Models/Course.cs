using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BryantUniversity.Models
{
    public class Course
    {
        public Course() { }

        public Course(string courseTitleId, string courseTitle, string description, int credits, int courseLevelId, int departmentId)
        {
            CourseTitleId = courseTitleId;
            CourseTitle = courseTitle;
            Description = description;
            Credits = credits;
            CourseLevelId = courseLevelId;
            DepartmentId = departmentId;
        }

        public Course(int id, string courseTitleId, string courseTitle, string description, int credits, int courseLevelId, int departmentId)
        {
            Id = id;
            CourseTitleId = courseTitleId;
            CourseTitle = courseTitle;
            Description = description;
            Credits = credits;
            CourseLevelId = courseLevelId;
            DepartmentId = departmentId;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string CourseTitleId { get; set; }
        [Required]
        public string CourseTitle { get; set; }
        [Required] 
        public string Description { get; set; }
        public int Credits { get; set; }
        public int CourseLevelId { get; set; }
        public CourseLevel CourseLevel { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<CourseSection> CourseCourseSections { get; set; }

    }
}