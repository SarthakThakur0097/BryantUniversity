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
        [Range(1, Int32.MaxValue, ErrorMessage = "Must Select A Value")]
        public int DepartmentId { get; set; }
        public IList<Course> Courses { get; set; }
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