using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class SemesterDetailsViewModel
    {
        public int Id { get; set; }
        
        [Required]
        [DisplayName("Semester: ")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Must Select A Value")]
        public int PeriodId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Must Select A Value")]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public IList<CalendarEvent> CalendarEvents { get; set; }
        public IList<SemesterPeriod> SemesterPeriods { get; set; }
        public IList<Department> Departments { get; set; }
        public List<ClassPattern> PatternsToDisplay { get; set; }
        public IList<Course> Courses { get; set; }
        public bool DisplayCourses { get; set; }
        public SemesterDetailsViewModel(){}

        public SelectList PeriodList
        {
            get
            {
                return new SelectList(SemesterPeriods, "Id", "Period.Value");
            }
        }

        public SelectList DepartmentList
        {
            get
            {
                return new SelectList(Departments, "Id", "Name");
            }
        }

        public void PopulateSelectList(IList<SemesterPeriod> populatedPeriods)
        {
            SemesterPeriods = populatedPeriods;
            
        }

        public void PopulateDepermentSelectList(IList<Department> populatedDepartments)
        {
            Departments = populatedDepartments;
        }
    }
}