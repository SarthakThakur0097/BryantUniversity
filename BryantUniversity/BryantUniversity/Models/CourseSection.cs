﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class CourseSection
    {
        public CourseSection(){}

        public int Id { get; set; }
        public Course Course { get; set; }
        public Room Room { get; set; }
        public DateTime TimeSlot { get; set; }
        public User Professor { get; set; }
        public int SectionNumber { get; set; }
    }
}