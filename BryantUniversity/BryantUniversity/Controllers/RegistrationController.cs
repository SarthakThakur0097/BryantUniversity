using BryantUniversity.Data;
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
                int totRegisteredSoFar = 0;
                StudentTimeType studentTimeType = stRepo.GetStudentTimeTypeUserId(CustomUser.User.Id);
                IList<Registration> studentRegistered = rRepo.GetRegistrationByUserIdAndPeriodId(studentId, 1);
                toAdd = csRepo.GetCourseSectionById(coursectionId);
                CourseSection roomCheck = csRepo.GetCourseSectionById(coursectionId);
                IList<Registration> allRegisteredSoFar = rRepo.GetRegistrationByUserAndCourseSection(CustomUser.User.Id, roomCheck.SemesterPeriodId);
                totRegisteredSoFar = studentRegistered.Count;
                IList<Registration> allRegistrationsforSection = rRepo.GetRegistrationsByCourseSectionId(coursectionId);
                IList<MajorPreRequisite> allReqs = mprRepo.GetAllMajorPrequisitesByCourse(toAdd.Course.Id);

                IList<Grade> allTakenCourses = gRepo.GetAllGradesByUserId(CustomUser.User.Id);

                if (toAdd.SemesterPeriodId != 1)
                {
                    TempData["IsPreviousSemesterConflict"] = true;

                    return RedirectToAction("Index", "Schedule");
                }

                else if (totRegisteredSoFar >= 4)
                {
                    TempData["FullTimeOverFlow"] = true;

                    return RedirectToAction("Index", "Schedule");
                }

                else if (allReqs.Count > 0 && allTakenCourses.Count == 0)
                {

                    TempData["HasNotTakenPrereq"] = true;

                    return RedirectToAction("Index", "Schedule");
                }
                else if(allReqs.Count > 0)
                {
                    foreach(var allRegistered in allRegisteredSoFar)
                    {
                        foreach(var preq in allReqs)
                        {
                            if(allRegistered.CourseSection.CourseId != preq.CourseId )
                            {
                                TempData["HasNotTakenPrereq"] = true;
                                return RedirectToAction("Index", "Schedule");
                            }
                        }
                    }
                }
                else if (allRegistrationsforSection.Count >= roomCheck.Room.RoomCapacity)
                {
                    TempData["SpaceLeftInRoom"] = false;

                    return RedirectToAction("Index", "Schedule");
                }


                studentHolds = hRepo.GetAllStudentHoldsByUserId(CustomUser.User.Id);

                if (studentHolds.Count > 0)
                {
                    TempData["HasHold"] = true;

                    return RedirectToAction("Index", "Schedule");
                }

                SemesterPeriod toAddPeriod = toAdd.SemesterPeriod;

                IList<Registration> registrations = rRepo.GetRegistrationByUserAndCourseSection(CustomUser.User.Id, coursectionId);
                IList<CourseSection> registeredCourseSections = new List<CourseSection>();

                foreach (Registration registration in registrations)
                {
                    if (registration.CourseSectionId == coursectionId)
                    {
                        TempData["SameClass"] = false;
                        return RedirectToAction("Index", "Schedule");
                    }
                    else if (registration.CourseSection.SemesterPeriod == toAddPeriod)
                    {
                        TempData["TimeConflict"] = false;
                        return RedirectToAction("Index", "Schedule");
                    }

                    foreach (var req in allReqs)
                    {
                        foreach (var takenCourse in allTakenCourses)
                        {

                            if (takenCourse.Registration.CourseSection.CourseId == req.CourseId)
                            {
                                TempData["Success"] = true;

                                Registration userCourseSection = new Registration(CustomUser.User.Id, toAdd.Id);
                                rRepo.Insert(userCourseSection);
                                return RedirectToAction("Index", "Schedule");
                            }
                            else
                            {
                                TempData["NotTakePreqs"] = true;
                                return RedirectToAction("Index", "Schedule");
                            }
                        }
                    }
                }
                if (registrations.Count == 0 && allReqs.Count == 0)
                {
                    TempData["Success"] = true;

                    Registration userCourseSection = new Registration(CustomUser.User.Id, toAdd.Id);
                    rRepo.Insert(userCourseSection);
                    return RedirectToAction("Index", "Schedule");
                }

            }
            return RedirectToAction("Index", "Schedule");
        }

        [HttpPost]
        public ActionResult Add(int courseSectionId, int semesterPeriodId)
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
                int totRegisteredSoFar = 0;
                StudentTimeType studentTimeType = stRepo.GetStudentTimeTypeUserId(CustomUser.User.Id);
                IList<Registration> studentRegistered = rRepo.GetRegistrationByUserIdAndPeriodId(CustomUser.User.Id, semesterPeriodId);
                toAdd = csRepo.GetCourseSectionById(courseSectionId);
                CourseSection roomCheck = csRepo.GetCourseSectionById(courseSectionId);
                IList<Registration> allRegisteredSoFar = rRepo.GetRegistrationByUserAndCourseSection(CustomUser.User.Id, roomCheck.SemesterPeriodId);
                totRegisteredSoFar = studentRegistered.Count;
                IList<Registration> allRegistrationsforSection = rRepo.GetRegistrationsByCourseSectionId(courseSectionId);
                IList<MajorPreRequisite> allReqs = mprRepo.GetAllMajorPrequisitesByCourse(toAdd.Course.Id);

                IList<Grade> allTakenCourses = gRepo.GetAllGradesByUserId(CustomUser.User.Id);

                if (toAdd.SemesterPeriodId != 1)
                {
                    TempData["IsPreviousSemesterConflict"] = true;

                    return RedirectToAction("Index", "Schedule");
                }
                //else if(studentTimeType.TimeTypes.TimeType == TimeType.PartTime && totRegisteredSoFar>=2)
                //{
                //    TempData["PartTimeTryFullTime"] = true;

                //    return RedirectToAction("Index", "Schedule", new
                //    {
                //        id = roomCheck.CourseId,
                //        semesterPeriodId = semesterPeriodId
                //    });
                //}
                else if( totRegisteredSoFar >=4)
                {
                    TempData["FullTimeOverFlow"] = true;

                    return RedirectToAction("Index", "Schedule");
                }
                //else if(studentLevel.CourseLevel.Level == Level.Undergraduate && toAdd.Course.CourseLevel.Level == Level.Graduate)
                //{
                //    TempData["UnderGradTryGrad"] = true;

                //    return RedirectToAction("Index", "CourseSection", new
                //    {
                //        id = roomCheck.CourseId,
                //        semesterPeriodId = semesterPeriodId
                //    });
                //}
                else if (allReqs.Count > 0 && allTakenCourses.Count == 0)
                {

                    TempData["HasNotTakenPrereq"] = true;

                    return RedirectToAction("Index", "Schedule");
                }
                else if(allReqs.Count >0)
                {
                    foreach(var prereq in allReqs)
                    {
                        
                    }
                }
                else if(allRegistrationsforSection.Count >= roomCheck.Room.RoomCapacity)
                {
                    TempData["SpaceLeftInRoom"] = false;

                    return RedirectToAction("Index", "Schedule");
                }


                studentHolds = hRepo.GetAllStudentHoldsByUserId(CustomUser.User.Id);

                if (studentHolds.Count > 0)
                {
                    TempData["HasHold"] = true;

                    return RedirectToAction("Index", "Schedule");
                }

                SemesterPeriod toAddPeriod = toAdd.SemesterPeriod;

                IList<Registration> registrations = rRepo.GetRegistrationByUserAndCourseSection(CustomUser.User.Id, courseSectionId);
                IList<CourseSection> registeredCourseSections = new List<CourseSection>();

                foreach (Registration registration in registrations)
                {
                    if (registration.CourseSectionId == courseSectionId)
                    {
                        TempData["SameClass"] = false;
                        return RedirectToAction("Index", "Schedule");
                    }
                    else if (registration.CourseSection.SemesterPeriod == toAddPeriod)
                    {
                        TempData["TimeConflict"] = false;
                        return RedirectToAction("Index", "Schedule");
                    }

                    foreach (var req in allReqs)
                    {
                        foreach (var takenCourse in allTakenCourses)
                        {

                            if (takenCourse.Registration.CourseSection.CourseId == req.CourseId)
                            {
                                TempData["Success"] = true;

                                Registration userCourseSection = new Registration(CustomUser.User.Id, toAdd.Id);
                                rRepo.Insert(userCourseSection);
                                return RedirectToAction("Index", "Schedule");
                            }
                            else
                            {
                                TempData["NotTakePreqs"] = true;
                                return RedirectToAction("Index", "Schedule");
                            }
                        }
                    }
                }
                if(registrations.Count == 0 && allReqs.Count == 0)
                {
                    TempData["Success"] = true;

                    Registration userCourseSection = new Registration(CustomUser.User.Id, toAdd.Id);
                    rRepo.Insert(userCourseSection);
                    return RedirectToAction("Index", "Schedule");
                }

            }
            return RedirectToAction("Index", "Schedule");
        }
    }
}