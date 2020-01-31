using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models
{
    public class Role
    {
        public int Id { get; set;}
        public string RoleName { get; set; }

        public Role(string roleName)
        {
            RoleName = roleName;
        }
    }
}