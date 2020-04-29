using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class Grade
    {
        public Grade() { }
         
        public Grade(int id, int finalGrade, int userId)
        {
            Id = id;
            FinalGrade = finalGrade;
            StudentId = userId;
        }

        public int Id { get; set; }
        public int FinalGrade { get; set; }
        public int RegistrationId { get; set; }
        public int StudentId { get; set; }
        public User StudentUser { get; set; }
    }
}