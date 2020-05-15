using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class AdvisorViewModel
    {
        public IList<User> AllFaculty { get; set; }
        public IList<Advisor> AllAdvisees { get; set; }
    }
}