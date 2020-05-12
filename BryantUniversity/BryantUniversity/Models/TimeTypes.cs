using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class TimeTypes
    {
        public TimeTypes() { }

        public TimeTypes(TimeType timeType)
        {
            TimeType = timeType;
        }

        public int Id { get; set; }
        public TimeType TimeType { get; set; }
    }
}