using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class SemesterDetailsViewModel
    {
        public int Id { get; set; }
        [DisplayName("Semester: ")]
        public int PeriodId { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public IList<CalendarEvent> CalendarEvents { get; set; }
        public IList<SemesterPeriod> SemesterPeriods { get; set; }
        public List<ClassPattern> PatternsToDisplay { get; set; }
      
        public SemesterDetailsViewModel()
        {

        }


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