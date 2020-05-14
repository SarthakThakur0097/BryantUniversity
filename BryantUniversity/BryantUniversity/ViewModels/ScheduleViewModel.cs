using BryantUniversity.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
	public class ScheduleViewModel
	{
        public ScheduleViewModel()
        {
            RegisteredClasses = new List<Registration>();
        }

        public IList<Registration> RegisteredClasses { get; set; }
        public SemesterPeriod GradeSemesterPeriod { get; set; }
        [DisplayName("Semester")]
        public int PeriodId { get; set; }
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