using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class MajorPreRequisites
    {
        public MajorPreRequisites(){ }

        public MajorPreRequisites(int majorRequirmentId, int courseId)
        {
            MajorRequirementsId = majorRequirmentId;
            CourseId = courseId;
        }

        public int Id { get; set; }
        public int MajorRequirementsId { get; set; }
        public MajorRequirements MajorRequirements { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}