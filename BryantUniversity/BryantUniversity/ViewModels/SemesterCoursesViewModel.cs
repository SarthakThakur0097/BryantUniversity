using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class SemesterCoursesViewModel
    {
        public int PeriodId { get; set; }
        public IList<Course> Courses { get; set; }
    }
}