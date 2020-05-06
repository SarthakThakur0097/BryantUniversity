using BryantUniversity.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class GradesViewModel
    {
        public GradesViewModel()
        {
            Grades = new List<Grade>();
        }

        public IList<Grade> Grades { get; set; }
        public SemesterPeriod GradeSemesterPeriod { get; set; }
        public int PeriodId { get; set; }
        public IList<SemesterPeriod> SemesterPeriods { get; set; }

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