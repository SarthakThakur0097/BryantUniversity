using System;
using System.Collections.Generic;
using System.Linq;
namespace BryantUniversity.Models
{
    public class FacultyTimeType
    {
        public FacultyTimeType() { }

        public FacultyTimeType(int userId, TimeTypes timeTypes)
        {
            UserId = userId;
            TimeTypes = timeTypes;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TimeTypesId { get; set; }
        public TimeTypes TimeTypes { get; set; }
    }
}