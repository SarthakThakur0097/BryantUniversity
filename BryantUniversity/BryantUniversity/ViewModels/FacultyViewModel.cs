using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class FacultyViewModel
    {
        public IList<CourseSection> Teaching { get; set; }
    }
}