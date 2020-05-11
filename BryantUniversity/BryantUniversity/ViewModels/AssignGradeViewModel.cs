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
        public int sectionId { get; set; }
        public User Student { get; set; }
        public CourseSection Section { get; set; }
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
