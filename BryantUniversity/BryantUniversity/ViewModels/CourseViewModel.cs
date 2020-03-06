using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public string Level { get; set; }
        public IList<Course> Courses { get; set; }
        public CourseViewModel() { }
    }
}