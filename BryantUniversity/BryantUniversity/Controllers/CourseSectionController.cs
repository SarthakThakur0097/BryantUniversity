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
        public ActionResult Index(int Id, int semesterPeriodId)
        {
            CourseSectionRepo csRepo;
            RegistrationRepo rRepo;
            IList<CourseSection> courseSections;
            IList<Registration> allRegisteredUsers;
            IList<SectionRegistrationViewModel> AllSections = new List<SectionRegistrationViewModel>();

            using (context)
            {
                rRepo = new RegistrationRepo(context);
                csRepo = new CourseSectionRepo(context);

                courseSections = csRepo.GetCourseSectionsByCourseIdAndSemesterPeriodId(Id, semesterPeriodId);

                foreach(var section in courseSections)
                {
                    allRegisteredUsers = rRepo.GetRegistrationBySectionIdAndPeriodId(section.Id, semesterPeriodId);
                    int roomsLeft = section.Room.RoomCapacity - allRegisteredUsers.Count;
                    SectionRegistrationViewModel viewModel = new SectionRegistrationViewModel
                    {
                        Section = section,
                        SeatsRemaining = roomsLeft
                       
                    };
                    AllSections.Add(viewModel);
                }
            }
            return View("Index", AllSections);
        }
    }
}