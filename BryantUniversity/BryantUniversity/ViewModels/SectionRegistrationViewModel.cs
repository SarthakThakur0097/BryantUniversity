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

        public bool IsPreviousSemesterConflict { get; set; }
        public bool PartTimeTryFullTime { get; set; }
        public bool UnderGradTryGrad { get; set; }
        public bool HasNotTakenPrereq { get; set; }
        public bool SpaceLeftInRoom { get; set; }
        public bool HasHold { get; set; }
        public bool SameClass { get; set; }
        public bool TimeConflict { get; set; }
        public bool Success { get; set; }
        public bool FullTimeOverFlow { get; set; }
    }
}