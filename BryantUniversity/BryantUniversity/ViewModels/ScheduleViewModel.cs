using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class ScheduleViewModel
    {
        public int PeriodId { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public IList<CalendarEvent> CalendarEvents { get; set; }
        public IList<SemesterPeriod> SemesterPeriods { get; set; }
        public List<ClassPattern> PatternsToDisplay { get; set; }

        public ScheduleViewModel(){}

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