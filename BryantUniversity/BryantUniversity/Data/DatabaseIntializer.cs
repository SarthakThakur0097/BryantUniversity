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
            User adminUser2 = new User("Admin2@gmail.com", "$2a$12$mgIW22sS2uhKTduaFNugJeym8Li6VnFlyNRDWBC7Oaf39lIaBkBOq", "Admin 2");
            User teacherUser = new User("Teacher@gmail.com", "$2a$12$mgIW22sS2uhKTduaFNugJeym8Li6VnFlyNRDWBC7Oaf39lIaBkBOq", "Teacher 1");
            User teacherUser2 = new User("Teacher2@gmail.com", "$2a$12$mgIW22sS2uhKTduaFNugJeym8Li6VnFlyNRDWBC7Oaf39lIaBkBOq", "Teacher 2");
            User studentUser = new User("Student@gmail.com", "$2a$12$mgIW22sS2uhKTduaFNugJeym8Li6VnFlyNRDWBC7Oaf39lIaBkBOq", "Student 1");

            UserRole adminRole = new UserRole(1, 2);
            UserRole teacherRole = new UserRole(2, 1);
            UserRole admin2Role = new UserRole(3, 1);
            UserRole teacher2Role = new UserRole(4, 2);
            UserRole studentRole = new UserRole(5, 4);

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

            SemesterPeriod Fall2020 = new SemesterPeriod(Period.Fall2020);
            SemesterPeriod Spring2020 = new SemesterPeriod(Period.Spring2020);
            SemesterPeriod Fall2019 = new SemesterPeriod(Period.Fall2019);
            SemesterPeriod Spring2019 = new SemesterPeriod(Period.Spring2019);

            CalendarEvent semEvent1 = new CalendarEvent(event1, "Continual registration for Spring 2020 for all students on the Web", Fall2020);
            CalendarEvent semEvent2 = new CalendarEvent(event2, "Advising for All students 10am – 6pm", Spring2020);
            CalendarEvent semEvent3 = new CalendarEvent(event3, "Advising for all students 10 A.M. – 4 P.M.", Fall2019);
            CalendarEvent semEvent4 = new CalendarEvent(event4, "Advising for All students 10am – 3pm", Fall2020);
            CalendarEvent semEvent5 = new CalendarEvent(event5, "Residence Halls Open", Fall2020);
            CalendarEvent semEvent6 = new CalendarEvent(event6, "Martin Luther King, Jr. Birthday observed", Fall2020);
            CalendarEvent semEvent7 = new CalendarEvent(event7, "Spring 2020 Classes begin", Fall2020);
            CalendarEvent semEvent8 = new CalendarEvent(event8, "Add/Drop (no fee)/Late Registration ($50 fee) on the Web ", Fall2020);
            CalendarEvent semEvent9 = new CalendarEvent(event9, "Lincoln’s Birthday – classes in session; offices minimally staffed", Fall2020);
            CalendarEvent semEvent10 = new CalendarEvent(event10, "	President’s Day – no classes; offices closed", Fall2020);
            CalendarEvent semEvent11 = new CalendarEvent(event11, "Applications for graduation (Registrar’s office) due from candidates who expect to complete requirements by May 2020", Fall2020);
            CalendarEvent semEvent12 = new CalendarEvent(event12, "	Advising begins in department offices for Fall 2020 registration (By appointment)", Fall2020);

            Building mainCampus = new Building("Main Campus", 8100);
            Room room1 = new Room(mainCampus.BuildingName, "Lecture", mainCampus);

            Department compSci = new Department("Computer Science", "516-389-2930");
            Course introToProg = new Course(0, "Intro to Computer Science", "Basic programming with Java", 4, "Level 100", compSci);

            FacultyDepartment facultyDepartment = new FacultyDepartment(teacherUser, compSci);
            CourseSection courseSection = new CourseSection(DateTime.Now, 5, introToProg, room1, teacherUser, Fall2020);
      
            context.Users.Add(adminUser);
            context.Users.Add(adminUser2);
      
            context.Users.Add(teacherUser);
            context.Users.Add(teacherUser2);

            context.Users.Add(studentUser);

            context.Roles.Add(admin);
            context.Roles.Add(faculty);
            context.Roles.Add(researcher);
            context.Roles.Add(student);

            context.UserRoles.Add(adminRole);
            context.UserRoles.Add(teacherRole);
            context.UserRoles.Add(admin2Role);
            context.UserRoles.Add(teacher2Role);
            context.UserRoles.Add(studentRole);

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

            context.Buildings.Add(mainCampus);
            context.Rooms.Add(room1);
            context.Departments.Add(compSci);

            context.Courses.Add(introToProg);
            context.CourseSections.Add(courseSection);
            context.FacultyDepartments.Add(facultyDepartment);

            context.SaveChanges();
        }
    }
}