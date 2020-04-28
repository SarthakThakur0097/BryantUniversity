using BryantUniversity.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BryantUniversity.Data
{
    public class Context : DbContext
    {
        //public Context()
        //  : base(Helpers.GetRDSConnectionString()){}

        public static Context Create()
        {
            return new Context();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<SemesterPeriod> SemesterPeriods { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<FacultyDepartment> FacultyDepartments {get; set;}
        public DbSet<Building> Buildings { get; set; }
        public DbSet<CourseSection> CourseSections { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}