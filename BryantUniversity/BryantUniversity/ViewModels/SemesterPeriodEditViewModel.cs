using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class SemesterPeriodEditViewModel
    {

        public int SemesterPeriodId { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Start Enrollment Date")]
        public DateTime StartEnrollmentDate { get; set; }
        [Display(Name = "End Enrollment Date")]
        public DateTime EndEnrollmentDate { get; set; }
        [Display(Name = "Grade Period Start ")]
        public DateTime StartGradeTime { get; set; }
        [Display(Name = "Grade Period End ")]
        public DateTime EndGradeTime { get; set; }
    }
}