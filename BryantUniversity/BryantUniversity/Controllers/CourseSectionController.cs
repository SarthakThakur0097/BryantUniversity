using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Repo;
using BryantUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BryantUniversity.Controllers
{
    public class CourseSectionController : Controller
    {
        private Context context;

        public CourseSectionController()
        {
            context = new Context();
        }

        [HttpGet]
        public ActionResult EditIndex()
        {
            CourseSectionRepo csRepo;
            EditCourseSectionViewModel viewModel = new EditCourseSectionViewModel();
            using (context)
            {
                csRepo = new CourseSectionRepo(context);
                viewModel.CourseSections = csRepo.GetAllCourseSections();
       
            }
            return View(viewModel);
        }


        [HttpGet]
        public ActionResult IndexAdmin(int id, int studentId, int semesterPeriodId)

        {
            SectionRegistrationViewModel viewModel = new SectionRegistrationViewModel();
            int courseSectionId = id;
            object PreviousSemester = TempData["IsPreviousSemesterConflict"];
            object PartTimeTryFullTime = TempData["PartTimeTryFullTime"];
            object UnderGradTryGrad = TempData["UnderGradTryGrad"];
            object HasNotTakenPrereq = TempData["HasNotTakenPrereq"];
            object SpaceLeftInRoom = TempData["SpaceLeftInRoom"];
            object HasHold = TempData["HasHold"];
            object SameClass = TempData["SameClass"];
            object TimeConflict = TempData["TimeConflict"];
           
            if (PreviousSemester != null)
            {
                if ((bool)PreviousSemester == true)
                {
                    viewModel.IsPreviousSemesterConflict = true;
                    RedirectToAction("IndexAdmin", "CourseSection", new { Id = courseSectionId, semesterPeriodId = semesterPeriodId });
                }
            }
            else if (PartTimeTryFullTime != null)
            {
                if (!(bool)PartTimeTryFullTime)
                {
                    viewModel.PartTimeTryFullTime = true;
                    RedirectToAction("IndexAdmin", "CourseSection", new { Id = courseSectionId, semesterPeriodId = semesterPeriodId });
                }
            }
            else if (UnderGradTryGrad != null)
            {
                if ((bool)UnderGradTryGrad)
                {
                    viewModel.UnderGradTryGrad = true;
                    RedirectToAction("IndexAdmin", "CourseSection", new { Id = courseSectionId, semesterPeriodId = semesterPeriodId });
                }
            }
            else if (HasNotTakenPrereq != null)
            {
                if (!(bool)HasNotTakenPrereq)
                {
                    viewModel.HasNotTakenPrereq = false;
                    RedirectToAction("IndexAdmin", "CourseSection", new { Id = courseSectionId, semesterPeriodId = semesterPeriodId });
                }
            }
            else if (SpaceLeftInRoom != null)
            {
                if (!(bool)SpaceLeftInRoom)
                {
                    viewModel.SpaceLeftInRoom = false;
                    RedirectToAction("IndexAdmin", "CourseSection", new { Id = courseSectionId, semesterPeriodId = semesterPeriodId });
                }
            }
            else if (HasHold != null)
            {
                if ((bool)HasHold)
                {
                    viewModel.HasHold = true;
                    RedirectToAction("IndexAdmin", "CourseSection", new { Id = courseSectionId, semesterPeriodId = semesterPeriodId });
                }
            }
            else if (SameClass != null)
            {
                if ((bool)SameClass)
                {
                    viewModel.SameClass = true;
                    RedirectToAction("IndexAdmin", "CourseSection", new { Id = courseSectionId, semesterPeriodId = semesterPeriodId });
                }
            }
            else if (SameClass != null)
            {
                if ((bool)TimeConflict)
                {
                    viewModel.TimeConflict = true;
                    RedirectToAction("IndexAdmin", "CourseSection", new { Id = courseSectionId, semesterPeriodId = semesterPeriodId });
                }
            }

            CourseSectionRepo csRepo;
            RegistrationRepo rRepo;
            IList<CourseSection> courseSections;
            IList<Registration> allRegisteredUsers;
            IList<SectionRegistrationViewModel> AllSections = new List<SectionRegistrationViewModel>();

            using (context)
            {
                rRepo = new RegistrationRepo(context);
                csRepo = new CourseSectionRepo(context);

                courseSections = csRepo.GetCourseSectionsByCourseIdAndSemesterPeriodId(id, semesterPeriodId);

                foreach (var section in courseSections)
                {
                    allRegisteredUsers = rRepo.GetRegistrationBySectionIdAndPeriodId(section.Id, semesterPeriodId);
                    int roomsLeft = section.Room.RoomCapacity - allRegisteredUsers.Count;
                    viewModel = new SectionRegistrationViewModel();
                    viewModel.StudentId = studentId;
                    viewModel.Section = section;
                    AllSections.Add(viewModel);
                }
            }
            return View("IndexAdmin", AllSections);
        }


        [HttpGet]
        public ActionResult Index(int id, int semesterPeriodId)
        {
            SectionRegistrationViewModel viewModel = new SectionRegistrationViewModel();

            using (context)
            {
                CourseSectionRepo csRepo;
                RegistrationRepo rRepo;
                IList<CourseSection> courseSections;
                IList<Registration> allRegisteredUsers;
                IList<SectionRegistrationViewModel> AllSections = new List<SectionRegistrationViewModel>();

                rRepo = new RegistrationRepo(context);
                csRepo = new CourseSectionRepo(context);

                courseSections = csRepo.GetCourseSectionsByCourseIdAndSemesterPeriodId(id, semesterPeriodId);

                foreach(var section in courseSections)
                {
                    allRegisteredUsers = rRepo.GetRegistrationBySectionIdAndPeriodId(section.Id, semesterPeriodId);
                    int roomsLeft = section.Room.RoomCapacity - allRegisteredUsers.Count;
                    viewModel = new SectionRegistrationViewModel();
                    viewModel.Section = section;
                    viewModel.SeatsRemaining = roomsLeft;
                    AllSections.Add(viewModel);
                }
                return View("Index", AllSections);
            }
        }
    }
}