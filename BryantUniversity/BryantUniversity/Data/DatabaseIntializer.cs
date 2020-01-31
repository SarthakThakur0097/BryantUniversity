using System.Data.Entity;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;

namespace BryantUniversity.Data
{
    public class DatabaseIntializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            RoleRepo roleRepo = new RoleRepo(context);

            Role admin = new Role()
            {
                RoleName = "Admin"
            };

            Role faculty = new Role()
            {
                RoleName = "Faculty"
            };

            Role student = new Role()
            {
                RoleName = "Student"
            };

            roleRepo.Insert(admin);
            roleRepo.Insert(faculty);
            roleRepo.Insert(student);
        }
    }
}