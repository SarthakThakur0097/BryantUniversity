﻿using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

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
            return _context
                        .Courses
                        .Include(c => c.Department)
                        .Include(c => c.CourseLevel)
                        .ToList();
        }

        public Course GetById(int id)
        {
            return _context
                        .Courses
                        .FirstOrDefault(c => c.Id == id);
        }

        public IList<Course> GetByDepartment(int id)
        {
            return _context
                        .Courses
                        .Include(c => c.CourseLevel)
                        .Include(c => c.Department)
                        .Where(c => c.DepartmentId == id)
                        .ToList();
        }

        public Course GetCourseByCourseTitleId(string id)
        {
            return _context
                        .Courses
                        .Include(c => c.Department)
                        .Include(c => c.CourseLevel)
                        .Where(c => c.CourseTitleId == id)
                        .FirstOrDefault();
        }

        public IList<Course> GetAllCoursesAndPreReqsByDepartment(int id)
        {
            return _context.Courses
                            .Include(c => c.MajorPreRequisites.Select(y => y.Course))
                            .Include(c => c.CourseLevel)
                            .Include(c => c.Department)
                            .Where(c => c.DepartmentId == id)
                            .ToList();
        }

        public void Insert(Course course)
        {
            _context
                .Courses
                .Add(course);
            _context.SaveChanges();
        }

        public void Update(Course course)
        {
            _context.Courses.Attach(course);
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Course course)
        {
            _context.Courses.Attach(course);
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
    }
}