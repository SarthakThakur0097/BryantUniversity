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
    [Authorize(Roles = "1,4")]
    public class RegistrationController : Controller
    {
        private Context context;

        public CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }

        public RegistrationController()
        {
            context = new Context();
        }

        [HttpGet]
        public ActionResult Index()
        {
            using (context)
            {
                User currUser = new UserRepo(context).GetByEmail(User.Identity.Name);
                IList<Registration> registration = new RegistrationRepo(context).GetRegistrationByUserId(currUser.Id);
                return View(registration);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            using (context) {
                IList<CourseSection> courseSections = new CourseSectionRepo(context).GetCourseSectionsByCourseId(id);
                return View(courseSections);
            }
        }

        [HttpPost]
        public ActionResult AdminAdd(int studentId, int coursectionId)
        {

            MajorPreRequisitesRepo mprRepo;
            StudentLevelRepo sLRepo;
            StudentTimeTypeRepo stRepo;
            CourseSectionRepo csRepo;
            RegistrationRepo rRepo;
            StudentHoldRepo hRepo;
            CourseSection toAdd;
            GradesRepo gRepo;
            IList<StudentHold> studentHolds = new List<StudentHold>();
            RegistrationViewModel viewModel = new RegistrationViewModel();

            using (context)
            {
                sLRepo = new StudentLevelRepo(context);
                stRepo = new StudentTimeTypeRepo(context);
                csRepo = new CourseSectionRepo(context);
                rRepo = new RegistrationRepo(context);
                hRepo = new StudentHoldRepo(context);
                mprRepo = new MajorPreRequisitesRepo(context);
                gRepo = new GradesRepo(context);
                StudentLevel studentLevel = sLRepo.GetLevelByUserId(CustomUser.User.Id);
                StudentTimeType studentTimeType = stRepo.GetStudentTimeTypeUserId(CustomUser.User.Id);

                toAdd = csRepo.GetCourseSectionById(coursectionId);
                CourseSection roomCheck = csRepo.GetCourseSectionById(coursectionId);
                IList<Registration> allRegisteredSoFar = rRepo.GetRegistrationByUserAndCourseSection(CustomUser.User.Id, roomCheck.SemesterPeriodId);
                IList<Registration> allRegistrationsforSection = rRepo.GetRegistrationsByCourseSectionId(coursectionId);
                IList<MajorPreRequisite> allReqs = mprRepo.GetAllMajorPrequisitesByCourse(toAdd.Course.Id);
                IList<Grade> allTakenCourses = gRepo.GetAllGradesByUserId(CustomUser.User.Id);

                if (toAdd.SemesterPeriodId != 1)
                {
                    TempData["IsPreviousSemesterConflict"] = true;

                    return RedirectToAction("Index", "CourseSection", new
                    {
                        id = studentId

                    });
                }
                else if (studentTimeType.TimeTypes.TimeType != TimeType.FullTime)
                {
                    TempData["IsFullTime"] = true;

                    return RedirectToAction("IndexAdmin", "CourseSection", new
                    {
                        id = studentId
                    });
                }
                else if (studentLevel.CourseLevel.Level == Level.Undergraduate && toAdd.Course.CourseLevel.Level == Level.Graduate)
                {
                    TempData["UnderGradTryGrad"] = true;

                    return RedirectToAction("Index", "CourseSection", new
                    {
                        id = studentId
                    });
                }
                else if (allReqs.Count > 0 && allTakenCourses.Count == 0)
                {

                    TempData["HasTakenPrereq"] = true;

                    return RedirectToAction("Index", "CourseSection", new
                    {
                        id = studentId
                    });
                }
                else if (allRegistrationsforSection.Count >= roomCheck.Room.RoomCapacity)
                {
                    TempData["SpaceLeftInRoom"] = false;

                    return RedirectToAction("Index", "CourseSection", new
                    {
                        id = studentId
                    });
                }
                foreach (var req in allReqs)
                {
                    foreach (var takenCourse in allTakenCourses)
                    {

                        if (takenCourse.Registration.CourseSection.CourseId != req.CourseId)
                        {
                            TempData["SpaceLeftInRoom"] = false;

                            return RedirectToAction("Index", "CourseSection", new
                            {
                                id = studentId
                            });
                        }
                    }
                }

                studentHolds = hRepo.GetAllStudentHoldsByUserId(CustomUser.User.Id);

                if (studentHolds.Count > 0)
                {
                    TempData["HasHold"] = false;

                    return RedirectToAction("Index", "CourseSection", new
                    {
                        id = studentId
                    });
                }
                SemesterPeriod toAddPeriod = toAdd.SemesterPeriod;

                IList<Registration> registrations = rRepo.GetRegistrationByUserAndCourseSection(studentId, roomCheck.Id);
                IList<CourseSection> registeredCourseSections = new List<CourseSection>();

                foreach (Registration registration in registrations)
                {
                    if (registration.CourseSectionId == roomCheck.Id)
                    {
                        TempData["AlreadyTaking"] = false;
                        return RedirectToAction("Index", "CourseSection", new
                        {
                            id = studentId
                        });
                    }
                    else if (registration.CourseSection.SemesterPeriod == toAddPeriod)
                    {
                        TempData["AnotherClassConflict"] = false;
                        return RedirectToAction("Index", "CourseSection", new
                        {
                            id = studentId
                        });
                    }
                }

                Registration userCourseSection = new Registration(studentId, toAdd.Id);
                rRepo.Insert(userCourseSection);
            }
            return RedirectToAction("Index", "Schedule");
        }

        [HttpPost]
        public ActionResult Add(int id, int semesterPeriodId)
        {

            MajorPreRequisitesRepo mprRepo;
            StudentLevelRepo sLRepo;
            StudentTimeTypeRepo stRepo;
            CourseSectionRepo csRepo;
            RegistrationRepo rRepo;
            StudentHoldRepo hRepo;
            CourseSection toAdd;
            GradesRepo gRepo;
            IList<StudentHold> studentHolds = new List<StudentHold>();
            RegistrationViewModel viewModel = new RegistrationViewModel();

            using (context)
            {
                sLRepo = new StudentLevelRepo(context);
                stRepo = new StudentTimeTypeRepo(context);
                csRepo = new CourseSectionRepo(context);
                rRepo = new RegistrationRepo(context);
                hRepo = new StudentHoldRepo(context);
                mprRepo = new MajorPreRequisitesRepo(context);
                gRepo = new GradesRepo(context);
                StudentLevel studentLevel = sLRepo.GetLevelByUserId(CustomUser.User.Id);
                StudentTimeType studentTimeType = stRepo.GetStudentTimeTypeUserId(CustomUser.User.Id);

                toAdd = csRepo.GetCourseSectionById(id);
                CourseSection roomCheck = csRepo.GetCourseSectionById(id);
                IList<Registration> allRegisteredSoFar = rRepo.GetRegistrationByUserAndCourseSection(CustomUser.User.Id, roomCheck.SemesterPeriodId);
                IList<Registration> allRegistrationsforSection = rRepo.GetRegistrationsByCourseSectionId(id);
                IList<MajorPreRequisite> allReqs = mprRepo.GetAllMajorPrequisitesByCourse(toAdd.Course.Id);
                IList<Grade> allTakenCourses = gRepo.GetAllGradesByUserId(CustomUser.User.Id);

                if (toAdd.SemesterPeriodId != 1)
                {
                    TempData["IsPreviousSemesterConflict"] = true;

                    return RedirectToAction("Index", "CourseSection", new
                    {
                        id = CustomUser.User.Id,
                        semesterPeriodId = semesterPeriodId
                    });
                }
                else if(studentTimeType.TimeTypes.TimeType != TimeType.FullTime)
                {
                    TempData["IsFullTime"] = true;

                    return RedirectToAction("Index", "CourseSection", new
                    {
                        id = CustomUser.User.Id,
                        semesterPeriodId = semesterPeriodId
                    });
                }
                else if(studentLevel.CourseLevel.Level == Level.Undergraduate && toAdd.Course.CourseLevel.Level == Level.Graduate)
                {
                    TempData["UnderGradTryGrad"] = true;

                    return RedirectToAction("Index", "CourseSection", new
                    {
                        id = CustomUser.User.Id,
                        semesterPeriodId = semesterPeriodId
                    });
                }
                else if (allReqs.Count > 0 && allTakenCourses.Count == 0)
                {

                    TempData["HasTakenPrereq"] = true;

                    return RedirectToAction("Index", "CourseSection", new
                    {
                        id = CustomUser.User.Id,
                        semesterPeriodId = semesterPeriodId
                    });
                }
                else if(allRegistrationsforSection.Count >= roomCheck.Room.RoomCapacity)
                {
                    TempData["SpaceLeftInRoom"] = false;

                    return RedirectToAction("Index", "CourseSection", new
                    {
                        id = CustomUser.User.Id,
                        semesterPeriodId = semesterPeriodId
                    });
                }
                foreach (var req in allReqs)
                {
                    foreach (var takenCourse in allTakenCourses)
                    {

                        if (takenCourse.Registration.CourseSection.CourseId != req.CourseId)
                        {
                            TempData["HasTakenPrereq"] = false;

                            return RedirectToAction("Index", "CourseSection", new
                            {
                                id = CustomUser.User.Id,
                                semesterPeriodId = semesterPeriodId
                            });
                        }
                    }
                }

                studentHolds = hRepo.GetAllStudentHoldsByUserId(CustomUser.User.Id);
               
                if (studentHolds.Count>0)
                {
                    TempData["HasHold"] = true;

                    return RedirectToAction("Index", "CourseSection", new
                    {
                        id = CustomUser.User.Id,
                        semesterPeriodId = semesterPeriodId
                    });
                }
                SemesterPeriod toAddPeriod = toAdd.SemesterPeriod;
                
                IList<Registration> registrations = rRepo.GetRegistrationByUserAndCourseSection(CustomUser.User.Id, id);
                IList<CourseSection> registeredCourseSections = new List<CourseSection>();

                foreach(Registration registration in registrations)
                {
                    if(registration.CourseSectionId == id)
                    {
                        TempData["SameClass"] = false;
                        return RedirectToAction("Index", "CourseSection", new
                        {
                            id = CustomUser.User.Id,
                            semesterPeriodId = semesterPeriodId
                        });
                    } 
                    else if (registration.CourseSection.SemesterPeriod == toAddPeriod)
                    {
                        TempData["TimeConflict"] = false;
                        return RedirectToAction("Index", "CourseSection", new
                        {
                            id = CustomUser.User.Id,
                            semesterPeriodId = semesterPeriodId
                        });
                    }
                }
        
                Registration userCourseSection = new Registration(CustomUser.User.Id, toAdd.Id);
                rRepo.Insert(userCourseSection);
            }
            return RedirectToAction("Index", "Schedule");
        }
    }
}