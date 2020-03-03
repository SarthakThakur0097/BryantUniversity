using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class FacultyDepartment
    {
        public int Id { get; set; }
        public int HoursWorked { get; set; }
        public List<User> Faculty { get; set; }
    }
}