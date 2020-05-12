using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class RegistrationViewModel
    {
        public bool PreviousSemesterConflict { get; set; }
        public bool NotTakenPreReqConflict { get; set; }
        public bool SameClassConflict { get; set; }
        public bool TimeConflict { get; set; }
        public bool HasHold { get; set; }
        public bool isOverRoomCapacity { get; set; }
    }
}