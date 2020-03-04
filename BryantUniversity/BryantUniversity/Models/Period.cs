namespace BryantUniversity.Models
{
    public class Period
    {
        public Period() { }

        private Period(string value)
        {
            Value = value;
        }
    
        public string Value { get; set; }

        public static Period Fall2020 { get { return new Period("Fall 2020"); } }
        public static Period Spring2020 { get { return new Period("Spring 2020"); } }
        public static Period Fall2019 { get { return new Period("Fall 2019"); } }
        public static Period Spring2019 { get { return new Period("Spring 2019"); } }
    }
}