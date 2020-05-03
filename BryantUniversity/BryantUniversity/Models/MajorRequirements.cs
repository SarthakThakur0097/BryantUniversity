﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class MajorRequirements
    {
        public MajorRequirements() { }

        public MajorRequirements(int majorId, int courseId)
        {
            MajorId = majorId;
            CourseId = courseId;
        }

        public int Id { get; set; }
        public int MajorId { get; set; }
        public Major Major { get; set; }
        public int CourseId { get; set; }
        public Course Course{ get; set; }
    }
}