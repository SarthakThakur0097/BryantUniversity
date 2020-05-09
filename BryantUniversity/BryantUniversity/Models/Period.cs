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
        public static Period Fall2018 { get { return new Period("Fall 2018"); } }
        public static Period Spring2018 { get { return new Period("Spring 2018"); } }
        public static Period Fall2017 { get { return new Period("Fall 2017"); } }
        public static Period Spring2017 { get { return new Period("Spring 2017"); } }
        public static Period Fall2016 { get { return new Period("Fall 2016"); } }


    }
}