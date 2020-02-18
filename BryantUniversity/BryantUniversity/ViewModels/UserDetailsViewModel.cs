using BryantUniversity.Models;
using System.Collections.Generic;

namespace BryantUniversity.ViewModels
{
    public class UserDetailsViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public List<Role> Roles { get; set; }

        public string RolesString
        {
            get
            {
                var rolesString = "";
                for (int i = 0; i < Roles.Count; i++)
                {
                    rolesString += Roles[i].RoleName;
                    if (i != Roles.Count - 1)
                    {
                        rolesString += ", ";
                    }
                }
                return rolesString; 
            }
        }
    }
}