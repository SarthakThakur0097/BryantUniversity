using BryantUniversity.Models;
using System.Collections.Generic;

namespace BryantUniversity.ViewModels
{
    public class SemesterDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }

        public IList<SemesterDetails> semesterDetails = new List<SemesterDetails>();

        public List<string> SemesterDates;

        public SemesterDetailsViewModel()
        {
            SemesterDates = new List<string>()
            {
                "Fall 2020",
                "Spring 2020",
                "Fall 2019",
                "Spring 2019"
            };
        }
    }
}