using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class StudentHoldViewModel
    {
        public User ToDisplay { get; set; }
        public IList<User> Users { get; set; }
        public IList<StudentHold> UserHolds { get; set; }

    }
}