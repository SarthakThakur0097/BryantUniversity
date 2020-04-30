using System.Data.Entity;
using BryantUniversity.Models;
using System;

namespace BryantUniversity.Data
{
    public class DatabaseIntializer : DropCreateDatabaseIfModelChanges<Context>
    {
        public object Response { get; private set; }

        protected override void Seed(Context context)
        {
            //context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Room', RESEED, 1000);");
            //context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Course', RESEED, 50000);");
            ////context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('CourseSection', RESEED, 100000);");
            //context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('User', RESEED, 700000);");
            //context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('UserRole', RESEED, 500000);");


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

            Hold financial = new Hold("Financial");
            Hold academic = new Hold("Academic");
            Hold disciplinary = new Hold("Disciplinary");

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

            DateTime fall2020StartTime = new DateTime(2020, 08, 27);
            DateTime fall2020EndTime = new DateTime(2021, 01, 22);

            DateTime spring2020StartTime = new DateTime(2020, 01, 2);
            DateTime spring2020EndTime = new DateTime(2020, 05, 17);

            DateTime fall2019StartTime = new DateTime(2019, 08, 25);
            DateTime fall2019EndTime = new DateTime(2020, 01, 17);

            DateTime spring2019StartTime = new DateTime(2019, 01, 5);
            DateTime spring2019EndTime = new DateTime(2019, 05, 23);

            SemesterPeriod Fall2020 = new SemesterPeriod(Period.Fall2020, fall2020StartTime, fall2020EndTime);
            SemesterPeriod Spring2020 = new SemesterPeriod(Period.Spring2020, spring2020StartTime, spring2020EndTime);
            SemesterPeriod Fall2019 = new SemesterPeriod(Period.Fall2019, fall2019StartTime, fall2019EndTime);
            SemesterPeriod Spring2019 = new SemesterPeriod(Period.Spring2019);

            ClassDuration NineToElvenAm = new ClassDuration(ClassTime.NineToElvenAm);
            ClassDuration ElvenAmToTwelvePm = new ClassDuration(ClassTime.ElvenAmToTwelvePm);
            ClassDuration OneToTwoPM = new ClassDuration(ClassTime.OneToTwoPM);
            ClassDuration ThreeFiftyToFiveTwentyPm = new ClassDuration(ClassTime.ThreeFiftyToFiveTwentyPm);
            ClassDuration FiveThirtyToSixFiftyPm = new ClassDuration(ClassTime.FiveThirtyToSixFiftyPm);
            ClassDuration SevenTenToEightThirtyPm = new ClassDuration(ClassTime.SevenTenToEightThirtyPm);

            Days MW = new Days(ClassPattern.Mw);
            Days TTR = new Days(ClassPattern.Ttr);
            Days F = new Days(ClassPattern.F);

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


            Building building = new Building("Kobe and Shaq", 8100);
            Room room = new Room("Lecture", 30, 1);

            Department compSci = new Department("Computer Science", "516-389-2930");
            Course introToProg = new Course(0,"Intro to Computer Science", "Basic programming with Java", 4, "Level 100", compSci);

            FacultyDepartment facultyDepartment = new FacultyDepartment(teacherUser, compSci);
            CourseSection courseSection = new CourseSection(0, 1, 1, 1, 1);
            //toInsert = new CourseSection(0, 10000, courseSection.CourseId, courseSection.RoomId, courseSection.UserId, courseSection.SemesterPeriodId);

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

            context.Holds.Add(financial);
            context.Holds.Add(academic);
            context.Holds.Add(disciplinary);

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

            context.ClassTimes.Add(NineToElvenAm);
            context.ClassTimes.Add(ElvenAmToTwelvePm);
            context.ClassTimes.Add(OneToTwoPM);
            context.ClassTimes.Add(ThreeFiftyToFiveTwentyPm);
            context.ClassTimes.Add(FiveThirtyToSixFiftyPm);
            context.ClassTimes.Add(SevenTenToEightThirtyPm);

            context.ClassDays.Add(MW);
            context.ClassDays.Add(TTR);
            context.ClassDays.Add(F);

            //context.Buildings.Add(mainCampus);
            //context.Rooms.Add(room1);
            context.Departments.Add(compSci);

            context.Courses.Add(introToProg);
            
            context.FacultyDepartments.Add(facultyDepartment);
            //context.Buildings.Add(building);
            //context.Rooms.Add(room);
            //context.CourseSections.Add(courseSection);
            context.SaveChanges();
        }
    }
}