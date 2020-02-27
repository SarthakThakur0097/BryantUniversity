using System.Data.Entity;
using BryantUniversity.Models;
using System;

namespace BryantUniversity.Data
{
    public class DatabaseIntializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            User adminUser = new User("Admin@gmail.com", "$2a$12$mgIW22sS2uhKTduaFNugJeym8Li6VnFlyNRDWBC7Oaf39lIaBkBOq", "Admin 1");
            UserRole userRole = new UserRole(1, 1);

            Role admin = new Role("Admin");
            Role faculty = new Role("Faculty");
            Role researcher = new Role("Researcher");
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

            SemesterDetails semEvent1 = new SemesterDetails(event1, "Continual registration for Spring 2020 for all students on the Web");
            SemesterDetails semEvent2 = new SemesterDetails(event2, "Advising for All students 10am – 6pm");
            SemesterDetails semEvent3 = new SemesterDetails(event3, "Advising for all students 10 A.M. – 4 P.M.");
            SemesterDetails semEvent4 = new SemesterDetails(event4, "Advising for All students 10am – 3pm");
            SemesterDetails semEvent5 = new SemesterDetails(event5, "Residence Halls Open");
            SemesterDetails semEvent6 = new SemesterDetails(event6, "Martin Luther King, Jr. Birthday observed");
            SemesterDetails semEvent7 = new SemesterDetails(event7, "Spring 2020 Classes begin");
            SemesterDetails semEvent8 = new SemesterDetails(event8, "Add/Drop (no fee)/Late Registration ($50 fee) on the Web ");
            SemesterDetails semEvent9 = new SemesterDetails(event9, "Lincoln’s Birthday – classes in session; offices minimally staffed");
            SemesterDetails semEvent10 = new SemesterDetails(event10, "	President’s Day – no classes; offices closed");
            SemesterDetails semEvent11 = new SemesterDetails(event11, "Applications for graduation (Registrar’s office) due from candidates who expect to complete requirements by May 2020");
            SemesterDetails semEvent12 = new SemesterDetails(event12, "	Advising begins in department offices for Fall 2020 registration (By appointment)");

            context.Users.Add(adminUser);
            context.UserRoles.Add(userRole);

            context.Roles.Add(admin);
            context.Roles.Add(faculty);
            context.Roles.Add(researcher);
            context.Roles.Add(student);

            context.CalendarEvents.Add(semEvent1);
            context.CalendarEvents.Add(semEvent2);
            context.CalendarEvents.Add(semEvent3);
            context.CalendarEvents.Add(semEvent4);
            context.CalendarEvents.Add(semEvent5);
            context.CalendarEvents.Add(semEvent6);
            context.CalendarEvents.Add(semEvent7);
            context.CalendarEvents.Add(semEvent8);
            context.CalendarEvents.Add(semEvent9);
            context.CalendarEvents.Add(semEvent10);
            context.CalendarEvents.Add(semEvent11);
            context.CalendarEvents.Add(semEvent12);
        }
    }
}