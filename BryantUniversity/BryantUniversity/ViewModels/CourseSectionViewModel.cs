using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class CourseSectionViewModel
    {
        public int SectionNumber { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
        public IList<Room> Rooms { get; set; }

        public int UserId { get; set; }
        public User Professor { get; set; }
        public IList<User> Professors { get; set; }

        public int SemesterPeriodId { get; set; }
        public SemesterPeriod SemesterPeriod { get; set; }
        
        public ClassPattern Pattern { get; set; }
        public IList<ClassPattern> ClassPatterns { get; set; }

        public int DepartmentId { get; set; }
        public IList<Department> Departments { get; set; }
        public int CourseLevelId { get; set; }
        public IList<CourseLevel> CourseLevels { get; set; }

        public List<ClassPattern> PatternsToDisplay { get; set; }


        public SelectList DepartmentList
        {
            get
            {
                return new SelectList(Departments, "Id", "Name");
            }
        }

        public void PopulateDepermentSelectList(IList<Department> populatedDepartments)
        {
            Departments = populatedDepartments;
        }

        public SelectList CourseLevelList
        {
            get
            {
                return new SelectList(CourseLevels, "Id", "Level.Value");
            }
        }

        public void PopulateLevelsSelectList(IList<CourseLevel> populatedCourseLevels)
        {
            CourseLevels = populatedCourseLevels;
        }

    }
}