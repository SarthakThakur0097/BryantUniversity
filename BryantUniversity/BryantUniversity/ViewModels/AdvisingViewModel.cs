using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class AdvisingViewModel
    {
        public AdvisingViewModel()
        {
            AllAdvisedStudent = new List<Advisor>();
        }

        public IList<Advisor> AllAdvisedStudent { get; set; }
    }
}