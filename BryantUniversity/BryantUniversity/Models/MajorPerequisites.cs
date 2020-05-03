using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class MajorPerequisites
    {
        public MajorPerequisites(){ }

        public int Id { get; set; }
        public int MajorRequirmentId { get; set; }
        public MajorRequirements MajorRequirements { get; set; }
        public int RequiredCourseId { get; set; }
        public Course Course { get; set; }
    }
}