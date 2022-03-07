using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class CoursePreReqViewModel
    {
        [Required]
        [Display(Name = "")]
        public int DepartmentId { get; set; }
        public IList<Course> Courses { get; set; }
        public IList<MajorPreRequisite> CoursesAndPreReqs { get; set; }
        [Display(Name = "Department: ")]
        public IList<Department> Departments { get; set; }

        public CoursePreReqViewModel() { }

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
    }
}