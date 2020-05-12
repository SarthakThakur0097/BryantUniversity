namespace BryantUniversity.Models
{
    public class Grade
    {
        public Grade() { }

        public Grade(int? gradeId, int registrationId)
        {
            LetterGradeId = gradeId;
            RegistrationId = registrationId;
        }

        public Grade(int id, int? gradeId, int registrationId)
        {
            Id = id;
            LetterGradeId = gradeId;
            RegistrationId = registrationId;
        }

        public int Id { get; set; }
        public int? LetterGradeId { get; set; }
        public LetterGrade LetterGrade { get; set; }
        public int RegistrationId { get; set; }
        public Registration Registration { get; set; }
    }
}