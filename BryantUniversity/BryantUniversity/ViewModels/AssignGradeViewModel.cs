using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class AssignGradeViewModel
    {
        public User Student { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string TextBoxData { get; set; }
        public IList<LetterGrade> LetterGrades { get; set; }

        public SelectList GradeList
        {
            get
            {
                return new SelectList(LetterGrades, "Id", "GradVal.Value");
            }
        }


        public void PopulateSelectList(IList<LetterGrade> populatedGrades)
        {
            LetterGrades = populatedGrades;
        }
    }
}
