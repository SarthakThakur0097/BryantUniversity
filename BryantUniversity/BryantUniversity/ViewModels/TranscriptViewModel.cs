using BryantUniversity.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class TranscriptViewModel
    {
        public TranscriptViewModel()
        {
            AllGradesClasses = new List<Grade>();

        }
        public int TotalCredits { get; set; }
        public float TermGpa { get; set; }
        public float CumulativeGpa { get; set; }
        public int PeriodId { get; set; }
        public IList<SemesterPeriod> SemesterPeriods { get; set; }
        public StudentMajor StudentMajor { get; set; }
        public IList<MajorRequirements> MajorRequirements { get; set; }
        public IList<Grade> AllGradesClasses { get; set; }

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