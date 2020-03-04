using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BryantUniversity.Repo
{
    public class CourseSectionRepo
    {
        private Context _context;

        public CourseSectionRepo(Context context)
        {
            _context = context;
        }

        public CourseSection GetCourseSectionById (int courseSectionId)
        {
            return _context.CourseSections
                            .Include(cR => cR.Course)
                            .Include(cR => cR.Professor)
                            .Include(cR => cR.Room)
                            .Include(cR => cR.SemesterPeriod)
                            .Include(cR => cR.Course.Department)
                            .Where(cR => cR.Id == courseSectionId)
                            .SingleOrDefault();
        }

        public IList<CourseSection> GetCourseSectionsByCourseId(int courseId)
        {
            return _context.CourseSections
                .Include(cR => cR.Course)
                .Include(cR => cR.Professor)
                .Include(cR => cR.Room)
                .Include(cR => cR.SemesterPeriod)
                .Include(cR => cR.Course.Department)
                .Where(cR => cR.Course.Id == courseId)
                .ToList();
        }
    }
}