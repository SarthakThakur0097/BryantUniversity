using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class StudentType
    {
        public StudentType() { }

        private StudentType(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static StudentType FullTime { get { return new StudentType("Full-Time"); } }
        public static StudentType PartTime { get { return new StudentType("Part-Time"); } }
    
    }
}