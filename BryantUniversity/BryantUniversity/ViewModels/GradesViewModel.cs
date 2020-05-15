using BryantUniversity.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class GradesViewModel
    {
        public GradesViewModel()
        {
            Grades = new List<Grade>();
        }

        public double? CumulativeGpa { get; set; }
        public double? SemesterGpa { get; set; }
        public IList<Grade> Grades { get; set; }
        public IList<Registration> RegisteredClasses { get; set; }
        public SemesterPeriod GradeSemesterPeriod { get; set; }
        [DisplayName("Semester: ")]
        public int PeriodId { get; set; }
        public IList<SemesterPeriod> SemesterPeriods { get; set; }
        public double Gpa { get; set; }
        public SelectList PeriodList
        {
            get
            {
                return new SelectList(SemesterPeriods, "Id", "Period.Value");
            }
        }

        public void PopulateSelectList(IList<SemesterPeriod> populatedPeriods)
        {
            SemesterPeriods = populatedPeriods;

        }
    }
}