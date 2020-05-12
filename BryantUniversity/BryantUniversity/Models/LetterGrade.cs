namespace BryantUniversity.Models
{
    public class LetterGrade
    {
        public LetterGrade() { }

        public LetterGrade(GradeVal gradeVal)
        {
            GradeVal = gradeVal;
        }

        public int Id { get; set; }
        public GradeVal GradeVal { get; set; }
    }
}