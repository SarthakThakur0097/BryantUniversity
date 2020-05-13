using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class SectionRegistrationViewModel
    {
        public int StudentId { get; set; }
        public int SeatsRemaining { get; set; }
        public CourseSection Section { get; set; }
    }
}