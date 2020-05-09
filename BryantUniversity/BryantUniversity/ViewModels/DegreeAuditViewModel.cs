using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class DegreeAuditViewModel
    {
        public IList<Grade> AllCourses { get; set; }
        public IList<MajorRequirements> MajorRequirements { get; set; }
        public StudentMajor StudentMajor { get; set; }
    }
}