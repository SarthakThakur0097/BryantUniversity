using BryantUniversity.Models;
using System.Collections.Generic;

namespace BryantUniversity.ViewModels
{
    public class StudentDetailsViewModel
    {
        public User Student { get; set; }
        public StudentLevel StudentLevel { get; set; }
        public StudentTimeType StudentTimeType { get; set; }
        public float CumulativeGpa { get; set; }
        public StudentMajor StudentMajor { get; set; }
        public IList<MajorRequirements> MajorRequirements { get; set; }
        public IList<Grade> AllGradesClasses { get; set; }
    }
}