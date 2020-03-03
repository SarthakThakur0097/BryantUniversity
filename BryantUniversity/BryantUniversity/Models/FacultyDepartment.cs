using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class FacultyDepartment
    {
        public FacultyDepartment() { }
        public FacultyDepartment (User teacher, Department department)
        {
            Faculty = teacher;
            Department = department; 
        }
        public int Id { get; set; }
        public int HoursWorked { get; set; }
        public int UserId { get; set; }
        public User Faculty { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }


    }
}