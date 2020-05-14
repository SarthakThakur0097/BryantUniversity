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
                        .Include(c => c.Department)
                        .Include(c => c.CourseLevel)
                        .Include(c => c.MajorPreRequisitesCourses)
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

        public Course GetAllPrereqs(int id)
        {
            return _context
                        .Courses
                        .Include(c => c.CourseLevel)
                        .Include(c => c.MajorPreRequisitesCourses)
                        .Include(c => c.Department)
                        .FirstOrDefault(c => c.Id == id);
        }

        public Course GetCourseByCourseTitleId(string id)
        {
            return _context
                        .Courses
                        .Include(c => c.Department)
                        .Include(c => c.CourseLevel)
                        .FirstOrDefault(c => c.CourseTitleId == id);
        }

        public IList<Course> GetAllCoursesAndPreReqsByDepartment(int id)
        {
            return _context.Courses
                            //.Include(c => c.MajorPreRequisites.Select(y => y.Course))
                            .Include(c => c.CourseLevel)
                            .Include(c => c.Department)
                            .Where(c => c.DepartmentId == id)
                            .ToList();
        }

        public Course GetAllPreReqsByCourseId(int id)
        {
            return _context.Courses
                            .Include(c => c.CourseMajorPreRequisites)
                            .Include(c => c.CourseLevel)
                            .Include(c => c.Department)
                            .FirstOrDefault(c => c.Id == id);
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
            MajorPreRequisitesRepo repo;

            repo = new MajorPreRequisitesRepo(_context);


            _context.Courses.Attach(course);
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
    }
}