﻿using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using BryantUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        private Context context;

        public CoursesController()
        {
            context = new Context();
        }

        [HttpGet]
        public ActionResult Index()
        {
            CoursesRepo courseRepo;
            CourseViewModel viewModel;
            IList<Course> courses;
            using (context)
            {
                courseRepo = new CoursesRepo(context);
                viewModel = new CourseViewModel();
                courses = courseRepo.GetAllCourses();
            }

            viewModel.Courses = courses;

            return View("Index", viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new CourseViewModel();
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel formModel)
        {
            CoursesRepo courseRepo;
            using (context)
            {
                courseRepo = new CoursesRepo(context);

                try
                {
                    var course = new Course(0,formModel.CourseTitle, formModel.Description, formModel.Credits, formModel.Level);
                    courseRepo.Insert(course);

                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    HandleDbUpdateException(ex);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CoursesRepo courseRepo;
            CourseViewModel viewModel = new CourseViewModel();
            Course course;
            using (context)
            {
                courseRepo = new CoursesRepo(context);
                course = courseRepo.GetById(id);

                
                viewModel.Id = course.Id;
                viewModel.CourseTitle = course.CourseTitle;
                viewModel.Description = course.Description;
                viewModel.Credits = course.Credits;
                viewModel.Level = course.Level;
            }
            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, Course course)
        {
            CoursesRepo courseRepo;
            Course newCourse;
            CourseViewModel viewModel = new CourseViewModel();
            using (context)
            {
                courseRepo = new CoursesRepo(context);
                try
                {
                    newCourse = new Course(id, course.CourseTitle, course.Description, course.Credits, course.Level);
                    viewModel.Id = id;
                    viewModel.CourseTitle = course.CourseTitle;
                    viewModel.Description = course.Description;
                    viewModel.Credits = course.Credits;
                    viewModel.Level = course.Level;
                    
                    courseRepo.Update(newCourse);
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    HandleDbUpdateException(ex);
                    newCourse = null;
                }
            }
            return View("Edit", viewModel);
        }

        private void HandleDbUpdateException(DbUpdateException ex)
        {
            if (ex.InnerException != null && ex.InnerException.InnerException != null)
            {
                SqlException sqlException =
                    ex.InnerException.InnerException as SqlException;
                if (sqlException != null && sqlException.Number == 2627)
                {
                    ModelState.AddModelError("CourTitle", "This course is already exists.");
                }
            }
        }
    }

}