using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class CourseViewModel
    {
        public CourseViewModel() { }

        public int Id { get; set; }

        public string CourseTitleId { get; set; }
        [Display(Name = "Course Title")]
        public string CourseTitle { get; set; }

        public string Description { get; set; }
        public int Credits { get; set; }
        public CourseLevel CourseLevel { get; set; }
        public IList<Course> Courses { get; set; }
        public IList<SemesterPeriod> SemesterPeriods { get; set; }
        public int ChosenPattern { get; set; }
        public int DepartmentId { get; set; }

        public List<ClassPattern> PatternsToDisplay { get; set; }


        //public SelectList PatternList
        //{
        //    get
        //    {
        //        return new SelectList(PatternsToDisplay, "ClassPattern", "");
        //    }
        //}


        //public void PopulateSelectList()
        //{
        //    PatternsToDisplay.Add(ClassPattern.MW);
        //    PatternsToDisplay.Add(ClassPattern.TueThurs);
        //}
    }
}