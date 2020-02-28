using BryantUniversity.Models;
using System.Collections.Generic;

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

        public SemesterDetailsViewModel()
        {

        }

        public SelectList PeriodList
        {
            get
            {
                return new SelectList(SemesterPeriods, "Id", "Period");
            }
        }

        public void PopulateSelectList(Context context)
        {
            SemesterPeriodRepo srRepo = new SemesterPeriodRepo(context);
            SemesterPeriods = srRepo.GetAllSemesterPeriods();
        }
    }
}