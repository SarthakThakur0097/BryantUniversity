namespace BryantUniversity.Models
{
    public class Level
    {
        public Level() { }

        private Level(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static Level Undergraduate { get { return new Level("Undergraduate"); } }
        public static Level Graduate { get { return new Level("Graduate"); } }

    }
}