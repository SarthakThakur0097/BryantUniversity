﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class Days
    {
        public Days() { }

        public Days(ClassPattern pattern)
        {
            Pattern = pattern;
        }

        public int Id { get; set; }
        public ClassPattern Pattern { get;set; }

        public List<CalendarEvent> SemesterDetails { get; set; }
    }
}