using System.Collections.Generic;

namespace BryantUniversity.Models
{
    public class Role
    {
        public Role() { }

        public Role(string roleName)
        {
            RoleName = roleName;
        }

        public int Id { get; set;}
        public string RoleName { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}