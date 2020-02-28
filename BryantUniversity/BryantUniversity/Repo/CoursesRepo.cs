using BryantUniversity.Data;
using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Repo
{
    public class CoursesRepo
    {
        private Context _context;

        public CoursesRepo(Context context)
        {
            _context = context;
        }

        public IList<Course> GetAllCourses()
        {
            return _context.Courses.ToList();

        }

        public Course GetById(int id)
        {
            return _context.Courses.SingleOrDefault(c => c.Id == id);
        }

        public void Insert(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void Update(Course course)
        {
            _context.Courses.Attach(course);
            _context.Entry(course).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}