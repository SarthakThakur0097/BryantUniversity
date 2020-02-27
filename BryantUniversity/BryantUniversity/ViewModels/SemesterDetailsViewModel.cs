using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
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