namespace BryantUniversity.Models
{
    public class GradeVal
    {
        public GradeVal() { }

        private GradeVal(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static GradeVal A { get { return new GradeVal("A"); } }
        public static GradeVal Aminus { get { return new GradeVal("A-"); } }
        public static GradeVal Bplus { get { return new GradeVal("B+"); } }
        public static GradeVal B { get { return new GradeVal("B"); } }
        public static GradeVal Bminus { get { return new GradeVal("B-"); } }
        public static GradeVal Cplus { get { return new GradeVal("C+"); } }
        public static GradeVal C { get { return new GradeVal("C"); } }
        public static GradeVal Cminus { get { return new GradeVal("C-"); } }
        public static GradeVal Dplus { get { return new GradeVal("D+"); } }
        public static GradeVal D { get { return new GradeVal("D"); } }
        public static GradeVal Dminus { get { return new GradeVal("D-"); } }
        public static GradeVal F { get { return new GradeVal("F"); } }
    }
}