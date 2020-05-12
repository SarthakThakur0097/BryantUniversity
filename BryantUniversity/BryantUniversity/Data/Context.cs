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
        public DbSet<TimeTypes> TimeTypes { get; set; }
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
        public DbSet<Advisor> Advisors { get; set; }
        public DbSet<StudentLevel> StudentLevels { get; set; }
        public DbSet<StudentTimeType> StudentsTimeType { get; set; }
        public DbSet<FacultyTimeType> FacultyTimeType { get; set; }
        public DbSet<StudentMajor> StudentMajors { get; set; }
        public DbSet<FacultyHistory> FacultyHistory { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<LetterGrade> LetterGrades { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<CourseSection>()
            .Property(p => p.CourseId).IsOptional();

            modelBuilder.Entity<Registration>()
            .Property(p => p.CourseSectionId).IsOptional();

            modelBuilder.Entity<Grade>()
            .Property(p => p.RegistrationId).IsOptional();

            modelBuilder.Entity<Course>()
            .HasMany<CourseSection>(c => c.CourseCourseSections)
            .WithOptional(x => x.Course)
            .WillCascadeOnDelete(true);


            //modelBuilder.Entity<Course>()
            //.HasMany<MajorPreRequisite>(c => c.CourseMajorPreRequisites)
            //.WithOptional(x => x.Course)
            //.WillCascadeOnDelete(false);


            modelBuilder.Entity<CourseSection>()
            .HasMany<Registration>(c => c.Schedules)
            .WithOptional(x => x.CourseSection)
            .WillCascadeOnDelete(true);


            modelBuilder.Entity<Registration>()
            .HasMany<Grade>(c => c.Grades)
            .WithOptional(x => x.Registration)
            .WillCascadeOnDelete(true);

            modelBuilder.Entity<MajorPreRequisite>()
            .HasRequired<Course>(s => s.Course)
            .WithMany(g => g.CourseMajorPreRequisites)
            .HasForeignKey<int>(s => s.CourseId);

            modelBuilder.Entity<MajorPreRequisite>()
            .HasOptional<Course>(s => s.PreReq)
            .WithMany(g => g.MajorPreRequisitesCourses)
            .HasForeignKey<int?>(s => s.PreReqId);

            //.HasMany<Course>(c => c.PreReq)




            //modelBuilder.Entity<Course>()
            //.HasMany(c => c.MajorPreRequisitesCourses)
            //.WithMany(m => m.PreReq)
            //.Map(m => {
            //    m.ToTable("MajorPreRequisite");
            //    m.MapLeftKey("CourseId");
            //    m.MapRightKey("PreReqId");
            //    })
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Course>()
            //.HasMany(c => c.MajorPreRequisitesCourses)
            //.WithMany(m => m.Course)
            //    .Map(m => {
            //     m.ToTable("MajorPreRequisite");
            //        m.MapLeftKey("PreReqId");
            //        m.MapRightKey("CourseId");
            //        })
            //.WillCascadeOnDelete(false);

            //modelBuilder.Entity<Course>()
            //.HasMany<MajorPreRequisite>(c => c.)
            //.WithOptional(x => x.Course)
            //.WillCascadeOnDelete(true);

            //modelBuilder.Entity<MajorPreRequisite>().HasRequired(m => m.Course)
            //  .WithMany(m => m.).HasForeignKey(m => m.CourseId);
            //modelBuilder.Entity<MajorPreRequisite>().HasRequired(m => m.Course)
            //          .WithMany(m => m.CourseMajorPreRequisites).HasForeignKey(m => m.PreReqId);
            //modelBuilder.Entity<Advisor>()
            //    .HasRequired(c => c.Student)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Registration>()
            //    .HasRequired(c => c.CourseSection)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Registration>()
            //    .HasRequired(c => c.User)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Major>()
            //    .HasRequired(c => c.Department)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Course>()
            //    .HasRequired(c => c.Department)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<MajorPreRequisite>()
            //    .HasRequired(c => c.Course)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<MajorRequirements>()
            //    .HasRequired(c => c.Course)
            //    .WithMany()
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<MajorRequirements>()
            //   .HasRequired(c => c.Major)
            //   .WithMany()
            //   .WillCascadeOnDelete(false);

            //modelBuilder.Entity<CourseSection>()
            //  .HasRequired(c => c.Professor)
            //  .WithMany()
            //  .WillCascadeOnDelete(false);


        }
    }
}