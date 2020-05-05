using BryantUniversity.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BryantUniversity.Data
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<Hold> Holds { get; set; }
        public DbSet<StudentHold> StudentHolds { get; set; }
        public DbSet<Days> ClassDays { get; set; }
        public DbSet<ClassDuration> ClassTimes { get; set; }
        public DbSet<SemesterPeriod> SemesterPeriods { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<FacultyDepartment> FacultyDepartments {get; set;}
        public DbSet<Building> Buildings { get; set; }
        public DbSet<CourseSection> CourseSections { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<MajorRequirements> MajorRequirements { get; set; }
        public DbSet<MajorPreRequisite> MajorPreRequisites { get; set; }
        public DbSet<Minor> Minors { get; set; }
        public DbSet<StudentLevel> StudentLevels { get; set; }
        public DbSet<StudentMajor> StudentMajors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}