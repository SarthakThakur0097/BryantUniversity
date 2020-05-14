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


            User adminUser = new User("Admin@gmail.com", "$2a$12$mgIW22sS2uhKTduaFNugJeym8Li6VnFlyNRDWBC7Oaf39lIaBkBOq", "Admin 1", "Address","City", "state", "ZipCode", "PhoneNumber");
            //User adminUser2 = new User("Admin2@gmail.com", "$2a$12$mgIW22sS2uhKTduaFNugJeym8Li6VnFlyNRDWBC7Oaf39lIaBkBOq", "Admin 2");
            //User teacherUser = new User("Teacher@gmail.com", "$2a$12$mgIW22sS2uhKTduaFNugJeym8Li6VnFlyNRDWBC7Oaf39lIaBkBOq", "Teacher 1");
            //User teacherUser2 = new User("Teacher2@gmail.com", "$2a$12$mgIW22sS2uhKTduaFNugJeym8Li6VnFlyNRDWBC7Oaf39lIaBkBOq", "Teacher 2");
            //User studentUser = new User("Student@gmail.com", "$2a$12$mgIW22sS2uhKTduaFNugJeym8Li6VnFlyNRDWBC7Oaf39lIaBkBOq", "Student 1");

            UserRole adminRole = new UserRole(1, 1);
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
            DateTime fall2020StartEnrollTime = new DateTime(2020, 07, 01);
            DateTime fall2020EndEnrollTime = new DateTime(2020, 09, 03);
            DateTime fall2020startGradeTime = new DateTime(2020, 09, 03);
            DateTime fall2020endGradeTime = new DateTime(2020, 09, 03);

            DateTime spring2020StartTime = new DateTime(2020, 01, 22);
            DateTime spring2020EndTime = new DateTime(2020, 05, 17);
            DateTime spring2020StartEnrollTime = new DateTime(2019, 11, 20);
            DateTime spring2020EndEnrollTime = new DateTime(2020, 01, 29);
            DateTime spring2020startGradeTime = new DateTime(2020, 09, 03);
            DateTime spring2020endGradeTime = new DateTime(2020, 09, 03);


            DateTime fall2019StartTime = new DateTime(2019, 09, 1);
            DateTime fall2019EndTime = new DateTime(2019, 12, 22);
            DateTime fall2019StartEnrollTime = new DateTime(2019, 09, 1);
            DateTime fall2019EndEnrollTime = new DateTime(2020, 12, 15);
            DateTime fall2019startGradeTime = new DateTime(2020, 09, 03);
            DateTime fall2019endGradeTime = new DateTime(2020, 12, 20);

            DateTime spring2019StartTime = new DateTime(2019, 01, 5);
            DateTime spring2019EndTime = new DateTime(2019, 05, 17);
            DateTime spring2019StartEnrollTime = new DateTime(2018, 12, 1);
            DateTime spring2019EndEnrollTime = new DateTime(2019, 01, 05);
            DateTime spring2019startGradeTime = new DateTime(2019, 01, 07);
            DateTime spring2019endGradeTime = new DateTime(2020, 05, 21);

            DateTime fall2018StartTime = new DateTime(2018, 08, 5);
            DateTime fall2018EndTime = new DateTime(2018, 12, 21);
            DateTime fall2018StartEnrollTime = new DateTime(2018, 11, 1);
            DateTime fall2018EndEnrollTime = new DateTime(2018, 05, 30);
            DateTime fall2018startGradeTime = new DateTime(2018, 09, 03);
            DateTime fall2018endGradeTime = new DateTime(2018, 09, 03);


            DateTime spring2018StartTime = new DateTime(2018, 01, 5);
            DateTime spring2018EndTime = new DateTime(2018, 05, 23);
            DateTime spring2018StartEnrollTime = new DateTime(2018, 11, 1);
            DateTime spring2018EndEnrollTime = new DateTime(2018, 05, 30);
            DateTime spring2018startGradeTime = new DateTime(2018, 09, 03);
            DateTime spring2018endGradeTime = new DateTime(2018, 09, 03);

            DateTime fall2017StartTime = new DateTime(2017, 01, 5);
            DateTime fall2017EndTime = new DateTime(2017, 05, 23);
            DateTime fall2017StartEnrollTime = new DateTime(2017, 11, 1);
            DateTime fall2017EndEnrollTime = new DateTime(2017, 05, 30);
            DateTime fall2017startGradeTime = new DateTime(2017, 09, 03);
            DateTime fall2017endGradeTime = new DateTime(2017, 09, 03);

            DateTime spring2017StartTime = new DateTime(2017, 01, 5);
            DateTime spring2017EndTime = new DateTime(2017, 05, 23);
            DateTime spring2017StartEnrollTime = new DateTime(2017, 11, 1);
            DateTime spring2017EndEnrollTime = new DateTime(2017, 05, 30);
            DateTime spring2017startGradeTime = new DateTime(2017, 09, 03);
            DateTime spring2017endGradeTime = new DateTime(2017, 09, 03);

            DateTime fall2016StartTime = new DateTime(2016, 01, 5);
            DateTime fall2016EndTime = new DateTime(2016, 05, 23);
            DateTime fall2016StartEnrollTime = new DateTime(2016, 11, 1);
            DateTime fall2016EndEnrollTime = new DateTime(2016, 05, 30);
            DateTime fall2016startGradeTime = new DateTime(2016, 09, 03);
            DateTime fall2016endGradeTime = new DateTime(2016, 09, 03);


            SemesterPeriod Fall2020 = new SemesterPeriod(Period.Fall2020, fall2020StartTime, fall2020EndTime, fall2020StartEnrollTime, fall2020EndEnrollTime, fall2020startGradeTime, fall2020endGradeTime);
            SemesterPeriod Spring2020 = new SemesterPeriod(Period.Spring2020, spring2020StartTime, spring2020EndTime, spring2020StartEnrollTime, spring2020EndEnrollTime, spring2020startGradeTime, spring2020endGradeTime);
            SemesterPeriod Fall2019 = new SemesterPeriod(Period.Fall2019, fall2019StartTime, fall2019EndTime, fall2019StartEnrollTime, fall2019EndEnrollTime, fall2019startGradeTime, fall2019endGradeTime);
            SemesterPeriod Spring2019 = new SemesterPeriod(Period.Spring2019, spring2019StartTime, spring2019EndTime, spring2019StartEnrollTime, spring2019EndEnrollTime, spring2019startGradeTime, spring2019endGradeTime);

            SemesterPeriod Fall2018 = new SemesterPeriod(Period.Fall2018, fall2018StartTime, fall2018EndTime, fall2018StartEnrollTime, fall2018EndEnrollTime, fall2018startGradeTime, fall2018endGradeTime);
            SemesterPeriod Spring2018 = new SemesterPeriod(Period.Spring2018, spring2018StartTime, spring2018EndTime, spring2018StartEnrollTime, spring2018EndEnrollTime, spring2018startGradeTime, spring2018endGradeTime);
            SemesterPeriod Fall2017 = new SemesterPeriod(Period.Fall2017, fall2017StartTime, fall2017EndTime, fall2017StartEnrollTime, fall2017EndEnrollTime, fall2017startGradeTime, fall2017endGradeTime);
            SemesterPeriod Spring2017 = new SemesterPeriod(Period.Spring2017, spring2017StartTime, spring2017EndTime, spring2017StartEnrollTime, spring2017EndEnrollTime, spring2017startGradeTime, spring2017endGradeTime);
            SemesterPeriod Fall2016 = new SemesterPeriod(Period.Fall2016, fall2016StartTime, fall2016EndTime, fall2016StartEnrollTime, fall2016EndEnrollTime, fall2016startGradeTime, fall2016endGradeTime);

            CourseLevel Undergraduate = new CourseLevel(Level.Undergraduate);
            CourseLevel Graduate = new CourseLevel(Level.Graduate);

            LetterGrade A = new LetterGrade(GradeVal.A);
            LetterGrade Aminus = new LetterGrade(GradeVal.Aminus);
            LetterGrade Bplus = new LetterGrade(GradeVal.Bplus);
            LetterGrade B = new LetterGrade(GradeVal.B);
            LetterGrade Bminus = new LetterGrade(GradeVal.Bminus);
            LetterGrade Cplus = new LetterGrade(GradeVal.Cplus);
            LetterGrade C = new LetterGrade(GradeVal.C);
            LetterGrade Cminus = new LetterGrade(GradeVal.Cminus);
            LetterGrade Dplus = new LetterGrade(GradeVal.Dplus);
            LetterGrade D = new LetterGrade(GradeVal.D);
            LetterGrade Dminus = new LetterGrade(GradeVal.Dminus);
            LetterGrade Fgrade = new LetterGrade(GradeVal.F);

            context.LetterGrades.Add(A);
            context.LetterGrades.Add(Aminus);
            context.LetterGrades.Add(Bplus);
            context.LetterGrades.Add(B);
            context.LetterGrades.Add(Bminus);
            context.LetterGrades.Add(Cplus);
            context.LetterGrades.Add(C);
            context.LetterGrades.Add(Cminus);
            context.LetterGrades.Add(Dplus);
            context.LetterGrades.Add(D);
            context.LetterGrades.Add(Dminus);
            context.LetterGrades.Add(Fgrade);
            TimeTypes PartTime = new TimeTypes(TimeType.FullTime);
            TimeTypes FullTime = new TimeTypes(TimeType.PartTime);


            context.TimeTypes.Add(FullTime);
            context.TimeTypes.Add(PartTime);
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
            //Course introToProg = new Course(0, "Intro to Computer Science", "Basic programming with Java", 4, "Level 100", compSci);

            //FacultyDepartment facultyDepartment = new FacultyDepartment(teacherUser, compSci);
            CourseSection courseSection = new CourseSection(0, 1, 1, 1, 1);
            //toInsert = new CourseSection(0, 10000, courseSection.CourseId, courseSection.RoomId, courseSection.UserId, courseSection.SemesterPeriodId);

            context.Users.Add(adminUser);
            //context.Users.Add(adminUser2);

            //context.Users.Add(teacherUser);
            //context.Users.Add(teacherUser2);

            //context.Users.Add(studentUser);

            context.Roles.Add(admin);
            context.Roles.Add(faculty);
            context.Roles.Add(researcher);
            context.Roles.Add(student);

            context.UserRoles.Add(adminRole);
            //context.UserRoles.Add(teacherRole);
            //context.UserRoles.Add(admin2Role);
            //context.UserRoles.Add(teacher2Role);
            //context.UserRoles.Add(studentRole);

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
            context.SemesterPeriods.Add(Spring2019);
     
            context.SemesterPeriods.Add(Fall2018);
            context.SemesterPeriods.Add(Spring2018);
            context.SemesterPeriods.Add(Fall2017);
            context.SemesterPeriods.Add(Spring2017);
            context.SemesterPeriods.Add(Fall2016);
            context.ClassTimes.Add(NineToElvenAm);
            context.ClassTimes.Add(ElvenAmToTwelvePm);
            context.ClassTimes.Add(OneToTwoPM);
            context.ClassTimes.Add(ThreeFiftyToFiveTwentyPm);
            context.ClassTimes.Add(FiveThirtyToSixFiftyPm);
            context.ClassTimes.Add(SevenTenToEightThirtyPm);

            context.ClassDays.Add(MW);
            context.ClassDays.Add(TTR);
            context.ClassDays.Add(F);

            context.CourseLevels.Add(Undergraduate);
            context.CourseLevels.Add(Graduate);
            //context.Buildings.Add(mainCampus);
            //context.Rooms.Add(room1);
            //context.Departments.Add(compSci);

            ////context.Courses.Add(introToProg);
            
            //context.FacultyDepartments.Add(facultyDepartment);
            //context.Buildings.Add(building);
            //context.Rooms.Add(room);
            //context.CourseSections.Add(courseSection);
            context.SaveChanges();
        }
    }
}