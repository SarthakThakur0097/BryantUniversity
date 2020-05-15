using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class StudentAttendanceViewModel
    {
        public int CourseSectionId { get; set; }
        public Registration Registration { get; set; }
        public IList<Registration> students { get; set; }
    }
}