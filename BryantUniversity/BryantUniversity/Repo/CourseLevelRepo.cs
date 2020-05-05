using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Linq;

namespace BryantUniversity.Repo
{
    public class CourseLevelRepo
    {
        private Context _context;

        public CourseLevelRepo(Context context)
        {
            _context = context;
        }

        public IList<CourseLevel> GetAllCourseLevels()
        {
            return _context
                        .CourseLevels
                        .ToList();
        }

        public CourseLevel GetById(int id)
        {
            return _context
                        .CourseLevels
                        .SingleOrDefault(c => c.Id == id);
        }

        public void Insert(CourseLevel courselevel)
        {
            _context
                .CourseLevels
                .Add(courselevel);

            _context.SaveChanges();
        }

        public void Update(CourseLevel courselevel)
        {
            _context.CourseLevels.Attach(courselevel);
            _context.Entry(courselevel).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}