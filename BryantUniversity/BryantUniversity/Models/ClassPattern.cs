namespace BryantUniversity.Models
{
    public class ClassPattern
    {
        public ClassPattern() { }

        private ClassPattern(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static ClassPattern Mw { get { return new ClassPattern("MW"); } }
        public static ClassPattern Ttr { get { return new ClassPattern("TTR"); } }
        public static ClassPattern F { get { return new ClassPattern("F"); } }
   
    }
}