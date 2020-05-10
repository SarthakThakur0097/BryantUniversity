﻿using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using BryantUniversity.Security;
using BryantUniversity.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    [Authorize(Roles = "2,1")]
    public class FacultyController : Controller
    {

        private Context context;

        public CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }

        public FacultyController()
        {
            context = new Context();
        }

        // GET: Faculty
        [HttpGet]
        public ActionResult Index()
        {
            UserListViewModel viewModel;
            UserRepo userRepository;
            using (context)
            {
                viewModel = new UserListViewModel();
                userRepository = new UserRepo(context);
                viewModel.Users = userRepository.GetAllUsers();
                    
                return View(viewModel);
            }
        }


        [HttpGet]
        public ActionResult Create()
        {
            var userViewModel = new UserViewModel();
            return View(userViewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userViewModel.Password);
                User user = new User(userViewModel.Email, hashedPassword, userViewModel.Name);
                UserRepo repository;

                using (context)
                {
                    repository = new UserRepo(context);
                    repository.Insert(user);

                    var roleRepo = new UserRoleRepo(context);
                    UserRole userRole;

                    int userId = repository.GetById(user.Id).Id;

                    switch (userViewModel.RoleType)
                    {
                        case RoleType.Admin:
                            userRole = new UserRole(userId, 1);
                            break;
                        case RoleType.Faculty:
                            userRole = new UserRole(userId, 2);
                            break;
                        case RoleType.Researcher:
                            userRole = new UserRole(userId, 3);
                            break;
                        case RoleType.Student:
                            userRole = new UserRole(userId, 4);
                            break;
                        default:
                            userRole = new UserRole();
                            break;
                    }

                    roleRepo.Insert(userRole);
                }
                return RedirectToAction("Create", "Faculty");
            }

            return View(userViewModel);
        }

        [HttpGet]
        public ActionResult All()
        {
            UserRepo uRepo;

            using (context)
            {
                uRepo = new UserRepo(context);

                uRepo.GetUsersByRole(2);
            }
                return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userViewModel = new UserViewModel();
            UserRepo uRepo;

            using (context)
            {
                uRepo = new UserRepo(context);
                User user = uRepo.GetById(id);

                userViewModel.Id = user.Id;
                userViewModel.Password = user.HashedPassword;
                userViewModel.Name = user.Name;
                userViewModel.Email = user.Email;
                userViewModel.City = user.City;
                userViewModel.Address = user.Address;
                userViewModel.State = user.State;
                userViewModel.ZipCode = user.ZipCode;
                userViewModel.PhoneNumber = user.PhoneNumber;
            }

            return View(userViewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(int id, UserViewModel userViewModel)
        {

                UserRepo repository;

                using (context)
                {
                    repository = new UserRepo(context);
                    User userId = repository.GetById(id);
                    User user = new User(userViewModel.Id, userId.HashedPassword, userViewModel.Email, userViewModel.Name, userViewModel.Address, userViewModel.City, userViewModel.State, userViewModel.ZipCode, userViewModel.PhoneNumber);

                    repository.Update(user);
                }

            return RedirectToAction("Index", "Faculty");
        }
        public ActionResult Teaching()
        {
            CourseSectionRepo csRepo;
            IList<CourseSection> classesTaught;
            using (context)
            {
                csRepo = new CourseSectionRepo(context);
                classesTaught = csRepo.GetCourseSectionByUserId(CustomUser.User.Id);
            }

            return View(classesTaught);
        }

        [HttpGet]
        public ActionResult Advising()
        {
            AdvisingViewModel viewModel = new AdvisingViewModel();
            AdviserRepo aRepo;

            using (context)
            {
                aRepo = new AdviserRepo(context);
                viewModel.AllAdvisedStudent = aRepo.GetAllAdvisedStudentsByAdviserId(CustomUser.User.Id);
            }
          
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult StudentDetails(int id)
        {
            StudentDetailsViewModel viewModel = new StudentDetailsViewModel();
            UserRepo uRepo;
            GradesRepo gRepo;
            using (context)
            {
                gRepo = new GradesRepo(context);
                uRepo = new UserRepo(context);
                viewModel.Student = uRepo.GetById(id);
                viewModel.AllGradesClasses = gRepo.GetAllGradesByUserId(id);
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Advising(AdvisingViewModel viewModel)
        {
            SemesterPeriodRepo sRepo;
            RegistrationRepo rRepo;
            ScheduleViewModel scheduleViewModel = new ScheduleViewModel();
            using (context)
            {

            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Students(int Id)
        {
            RegistrationRepo sRepo;
            StudentAttendanceViewModel viewModel = new StudentAttendanceViewModel();
            viewModel.CourseSectionId = Id;
            using (context)
            {
                sRepo = new RegistrationRepo(context);

                viewModel.students = sRepo.GetRegistrationsByCourseSectionId(Id);
            }
                return View(viewModel);
        }


        public ActionResult Advisor(int id)
        {
            UserListViewModel viewModel;
            UserRepo userRepository;
            using (context)
            {
                viewModel = new UserListViewModel();
                userRepository = new UserRepo(context);
                viewModel.Users = userRepository.GetUsersByRole(2);

                return View(viewModel);
            }
        }

        public ActionResult Assign(int id, int facultyId)
        {
            
            Advisor advisor;

            using (context)
            {
                User student = new UserRepo(context).GetById(id);
                User faculty = new UserRepo(context).GetById(facultyId);

                advisor = new Advisor(faculty, student);

                RegistrationRepo repository = new RegistrationRepo(context);
                repository.Insert(advisor);

                return RedirectToAction("Index", "Faculty");
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            FacultyViewModel viewModel = new FacultyViewModel();
            CourseSectionRepo uRepo;

            using (context)
            {
                uRepo = new CourseSectionRepo(context);
                viewModel.Teaching = uRepo.GetCourseSectionByUserId(id);
            }

            return View(viewModel);
        }
    }
}
