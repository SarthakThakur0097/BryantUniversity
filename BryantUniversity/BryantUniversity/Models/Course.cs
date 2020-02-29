using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string CourseTitle { get; set; }
        [Required]
        public string Description { get; set; }
        public int Credits { get; set; }
        [Required]
        public string Level { get; set; }

        public Course() { }

        public Course(int id, string courseTitle, string description, int credits, string level)
        {
            Id = id;
            CourseTitle = courseTitle;
            Description = description;
            Credits = credits;
            Level = level;
        }


    }
}