using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BryantUniversity.Models
{
    public class Department
    {
        public Department() { }

        public Department(string name, string contactNumber)
        {
            Name = name;
            ContactNumber = contactNumber;
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        public List<Course> DepartmentCourses { get; set; }
    }
}