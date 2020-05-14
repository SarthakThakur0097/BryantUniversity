namespace BryantUniversity.Models
{
    public class CourseLevel
    {
        public CourseLevel() { }

        public CourseLevel(Level level)
        {
            Level = level;
        }

        public int Id { get; set; }
        virtual public Level Level { get; set; }
    }
}