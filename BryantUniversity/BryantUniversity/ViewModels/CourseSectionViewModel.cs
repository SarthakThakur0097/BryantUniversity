using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.ViewModels
{
    public class CourseSectionViewModel
    {
        public int SectionNumber { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int UserId { get; set; }
        public User Professor { get; set; }
        public int SemesterPeriodId { get; set; }
        public SemesterPeriod SemesterPeriod { get; set; }
        public ClassPattern Pattern { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}