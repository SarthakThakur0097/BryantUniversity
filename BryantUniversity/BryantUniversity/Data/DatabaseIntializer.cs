using System.Data.Entity;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using System;

namespace BryantUniversity.Data
{
    public class DatabaseIntializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            User adminUser = new User("Admin@gmail.com", "$2a$12$mgIW22sS2uhKTduaFNugJeym8Li6VnFlyNRDWBC7Oaf39lIaBkBOq", "Admin 1");

            UserRepo userRepo = new UserRepo(context);
            RoleRepo roleRepo = new RoleRepo(context);
            UserRoleRepo userRoleRepo = new UserRoleRepo(context);
            CalendarRepo calendarRepo = new CalendarRepo(context);

            userRepo.Insert(adminUser);

            int adminId = userRepo.GetByEmail("Admin@gmail.com").Id;

            UserRole userRole = new UserRole(adminId, 1);

            userRoleRepo.Insert(userRole);

            Role admin = new Role("Admin");

            Role faculty = new Role("Faculty");

            Role student = new Role("Student");

            var event1 = new DateTime(2020, 1, 2);
            var event2 = new DateTime(2020, 1, 16);
            var event3 = new DateTime(2020, 1, 17);
            var event4 = new DateTime(2020, 1, 17);
            var event5 = new DateTime(2020, 1, 20);
            var event6 = new DateTime(2020, 1, 20);
            var event7 = new DateTime(2020, 2, 12);
            var event8 = new DateTime(2020, 2, 17);
            var event9 = new DateTime(2020, 3, 2);
            var event10 = new DateTime(2020, 3, 2);
            var event11 = new DateTime(2020, 3, 9);
            var event12 = new DateTime(2020, 3, 14);
            var event13 = new DateTime(2020, 3, 21);
            var event14 = new DateTime(2020, 3, 23);
            var event15 = new DateTime(2020, 3, 25);

            SemesterPeriod Fall2020 = new SemesterPeriod("Fall 2020");
            SemesterPeriod Spring2020 = new SemesterPeriod("Spring 2019");
            SemesterPeriod Fall2019 = new SemesterPeriod("Fall 2019");
            SemesterPeriod Spring2019 = new SemesterPeriod("Spring 2019");

            CalendarEvent semEvent1 = new CalendarEvent(event1, "Continual registration for Spring 2020 for all students on the Web", Fall2020);

            CalendarEvent semEvent2 = new CalendarEvent(event2, "Advising for All students 10am – 6pm", Spring2020);
           // semEvent2.SemesterPeriods.Add(Fall2020);
            CalendarEvent semEvent3 = new CalendarEvent(event3, "Advising for all students 10 A.M. – 4 P.M.", Fall2019);
            //semEvent3.SemesterPeriods.Add(Fall2020);
            CalendarEvent semEvent4 = new CalendarEvent(event4, "Advising for All students 10am – 3pm", Fall2020);
            //semEvent4.SemesterPeriods.Add(Fall2020);
            CalendarEvent semEvent5 = new CalendarEvent(event5, "Residence Halls Open", Fall2020);
            //semEvent5.SemesterPeriods.Add(Fall2020);
    
            CalendarEvent semEvent6 = new CalendarEvent(event6, "Martin Luther King, Jr. Birthday observed", Fall2020);
            //semEvent6.SemesterPeriods.Add(Fall2020);
            CalendarEvent semEvent7 = new CalendarEvent(event7, "Spring 2020 Classes begin", Fall2020);
            //semEvent7.SemesterPeriods.Add(Fall2020);

            CalendarEvent semEvent8 = new CalendarEvent(event8, "Add/Drop (no fee)/Late Registration ($50 fee) on the Web ", Fall2020);
           // semEvent8.SemesterPeriods.Add(Fall2020);
            CalendarEvent semEvent9 = new CalendarEvent(event9, "Lincoln’s Birthday – classes in session; offices minimally staffed", Fall2020);
           // semEvent9.SemesterPeriods.Add(Fall2020);

            CalendarEvent semEvent10 = new CalendarEvent(event10, "	President’s Day – no classes; offices closed", Fall2020);
            //semEvent10.SemesterPeriods.Add(Fall2020);
            CalendarEvent semEvent11 = new CalendarEvent(event11, "Applications for graduation (Registrar’s office) due from candidates who expect to complete requirements by May 2020", Fall2020);
            //semEvent11.SemesterPeriods.Add(Fall2020);
            CalendarEvent semEvent12 = new CalendarEvent(event12, "	Advising begins in department offices for Fall 2020 registration (By appointment)", Fall2020);
            //semEvent12.SemesterPeriods.Add(Fall2020);
            calendarRepo.Insert(semEvent1);
            calendarRepo.Insert(semEvent2);
            calendarRepo.Insert(semEvent3);
            calendarRepo.Insert(semEvent4);
            calendarRepo.Insert(semEvent5);
            calendarRepo.Insert(semEvent6);

            calendarRepo.Insert(semEvent7);
            calendarRepo.Insert(semEvent8);
            calendarRepo.Insert(semEvent9);
            calendarRepo.Insert(semEvent10);
            calendarRepo.Insert(semEvent11);
            calendarRepo.Insert(semEvent12);

            roleRepo.Insert(admin);
            roleRepo.Insert(faculty);
            roleRepo.Insert(student);
       
        }
    }
}