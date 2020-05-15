using System.Collections.Generic;

namespace BryantUniversity.Models
{
    public class Advisor
    {
        public Advisor() {}


        public Advisor(int facultyId, int studentId)
        {
            FacultyId = facultyId;
            StudentId = studentId;
        }

        public Advisor(User faculty, User student)
        {
            Faculty = faculty;
            Student = student;
        }

        public int Id { get; set; }
        public int FacultyId { get; set; }
        public User Faculty { get; set; }
        public int StudentId { get; set; }
        public User Student { get; set; }
    }
}