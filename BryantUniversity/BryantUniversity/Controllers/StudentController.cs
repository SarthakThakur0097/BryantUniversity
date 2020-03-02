﻿using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class StudentController : Controller
    {
        Context context;

        public StudentController()
        {
            context = new Context();
        }
        // GET: Student
        public ActionResult Index()
        {
            UserRoleRepo urRepo;
            UserViewModel viewModel = new UserViewModel();
            using (context)
            {
                urRepo = new UserRoleRepo(context);
                viewModel.Users = urRepo.GetUsersByRole(4);

            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            UserRepo userRepo;
            UserViewModel viewModel = new UserViewModel();
            User student;
            using (context)
            {
                userRepo = new UserRepo(context);
                student = userRepo.GetById(id);


                viewModel.Id = student.Id;
                viewModel.Email = student.Email;
                viewModel.Name = student.Name;
            }
            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, User student)
        {
            UserRepo userRepo;
            User newStudent;
            UserViewModel viewModel = new UserViewModel();
            using (context)
            {
                userRepo = new UserRepo(context);
                try
                {
                    newStudent = new User(id, student.Email, student.HashedPassword, student.Name);
                    viewModel.Id = id;
                    viewModel.Email = student.Email;
                    viewModel.Name = student.Name; 

                    userRepo.Update(newStudent);
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    HandleDbUpdateException(ex);
                    newStudent = null;
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