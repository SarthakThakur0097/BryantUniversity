using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class TimeType
    {
        public TimeType() { }

        private TimeType(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static TimeType FullTime { get { return new TimeType("Full-Time"); } }
        public static TimeType PartTime { get { return new TimeType("Part-Time"); } }
    
    }
}