
namespace BryantUniversity.Models
{
    public class ClassTime
    {
        public ClassTime() { }

        private ClassTime(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static ClassTime NineToElvenAm { get { return new ClassTime("9:40AM-11:10AM"); } }
        public static ClassTime ElvenAmToTwelvePm { get { return new ClassTime("11:20AM-12:50PM"); } }
        public static ClassTime OneToTwoPM { get { return new ClassTime("1:00PM-:2:00PM"); } }
        public static ClassTime ThreeFiftyToFiveTwentyPm { get { return new ClassTime("3:50PM-:5:20PM"); } }
        public static ClassTime FiveThirtyToSixFiftyPm { get { return new ClassTime("5:30PM-6:50PM"); } }
        public static ClassTime SevenTenToEightThirtyPm { get { return new ClassTime("7:10PM-:8:30PM"); } }
    }
}