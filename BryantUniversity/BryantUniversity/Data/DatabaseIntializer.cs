using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;

namespace BryantUniversity.Data
{
    public class DatabaseIntializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            User adminUser = new User("Admin@gmail.com", "1234", "Admin 1");

            UserRepo userRepo = new UserRepo(context);
            RoleRepo roleRepo = new RoleRepo(context);
            UserRoleRepo userRoleRepo = new UserRoleRepo(context);

            userRepo.Insert(adminUser);

            int adminId = userRepo.GetByEmail("Admin@gmail.com").Id;

            UserRole userRole = new UserRole(adminId, 1);

            userRoleRepo.Insert(userRole);

            Role admin = new Role("Admin");

            Role faculty = new Role("Faculty");

            Role student = new Role("Student");

            roleRepo.Insert(admin);
            roleRepo.Insert(faculty);
            roleRepo.Insert(student);
        }
    }
}