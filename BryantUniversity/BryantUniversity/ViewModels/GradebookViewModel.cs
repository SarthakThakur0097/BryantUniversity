using BryantUniversity.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class GradebookViewModel
    {
        public IList<Grade> AllGrades { get; set; }
        [DisplayName("Grade: ")]
        public int LetterGradeId { get; set; }
        public IList<LetterGrade> LetterGrades { get; set; }

        public SelectList GradeList
        {
            get
            {
                return new SelectList(LetterGrades, "Id", "GradeVal.Value");
            }
        }


        public void PopulateSelectList(IList<LetterGrade> populatedGrades)
        {
            LetterGrades = populatedGrades;
        }
    }
}