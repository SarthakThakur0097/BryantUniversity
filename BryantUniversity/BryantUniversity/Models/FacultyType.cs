using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class FacultyType
    {
        public FacultyType(){}

        private FacultyType(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static FacultyType FullTime { get { return new FacultyType("Full-Time"); } }
        public static FacultyType PartTime { get { return new FacultyType("Part-Time"); } }
    }
}