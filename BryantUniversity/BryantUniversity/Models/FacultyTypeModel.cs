using System;
using System.Collections.Generic;
using System.Linq;
namespace BryantUniversity.Models
{
    public class FacultyTypeModel
    {
        public FacultyTypeModel() { }

        public FacultyTypeModel(int userId, FacultyType facultyType)
        {
            UserId = userId;
            FacultyType = facultyType;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int FacultyTypeId { get; set; }
        public FacultyType FacultyType { get; set; }
    }
}