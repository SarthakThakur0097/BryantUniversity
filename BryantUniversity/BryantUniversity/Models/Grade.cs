using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BryantUniversity.Models
{
    public class Grade
    {
        public Grade() { }
        public Grade(int id, int grade, int registrationId)
        {
            Id = id;
            FinalGrade = grade;
            RegistrationId = registrationId;
        }
        public int Id { get; set; }
        public int FinalGrade { get; set; }
        public int RegistrationId { get; set; }
        public Registration Registration { get; set; }
    }
}