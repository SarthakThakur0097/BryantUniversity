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

        [Display(Name = "Course Id")]
        public string CourseTitleId { get; set; }
        [Display(Name = "Course Title")]
        public string CourseTitle { get; set; }
        public int CoursePrereqId { get; set; }
        public string Description { get; set; }
        [Range(1, 4, ErrorMessage = "Value must be between 1 - 4")]
        public int Credits { get; set; }
        [Display(Name = "Level")]
        public CourseLevel CourseLevel { get; set; }
        public IList<Course> Courses { get; set; }
        public IList<SemesterPeriod> SemesterPeriods { get; set; }
        public int ChosenPattern { get; set; }
        public bool SameTitleId { get; set; }
        [Display(Name = "Department: ")]
        public int DepartmentId { get; set; }

        public IList<Department> Departments { get; set; }
        public int CourseLevelId { get; set; }
        public IList<CourseLevel> CourseLevels { get; set; }

        public List<ClassPattern> PatternsToDisplay { get; set; }

        public SelectList DepartmentList
        {
            get
            {
                return new SelectList(Departments, "Id", "Name");
            }
        }

        public void PopulateDepermentSelectList(IList<Department> populatedDepartments)
        {
            Departments = populatedDepartments;
        }

        public SelectList CourseLevelList
        {
            get
            {
                return new SelectList(CourseLevels, "Id", "Level.Value");
            }
        }

        public void PopulateLevelsSelectList(IList<CourseLevel> populatedCourseLevels)
        {
            CourseLevels = populatedCourseLevels;
        }
    }
}