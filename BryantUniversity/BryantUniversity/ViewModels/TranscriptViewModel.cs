using BryantUniversity.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class TranscriptViewModel
    {
        public TranscriptViewModel()
        {
            AllGradesClasses = new List<Registration>();
            AllNonGradedClasses = new List<Registration>();
        }
        public float TermGpa { get; set; }
        public float CumulativeGpa { get; set; }
        public int PeriodId { get; set; }
        public IList<Registration> AllGradesClasses { get; set; }
        public IList<Registration> AllNonGradedClasses { get; set; }
        public SemesterPeriod GradeSemesterPeriod { get; set; }
        public IList<SemesterPeriod> SemesterPeriods { get; set; }
        public bool HasClasses { get; set; }
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