using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class EditCourseSectionViewModel
    {
        public IList<CourseSection> CourseSections { get; set; }
    }
}