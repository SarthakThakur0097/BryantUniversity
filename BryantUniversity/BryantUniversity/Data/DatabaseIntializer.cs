using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BryantUniversity.Models;
namespace BryantUniversity.Data
{
    public class DatabaseIntializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
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
        }
    }
}