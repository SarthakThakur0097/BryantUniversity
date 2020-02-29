using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BryantUniversity.Models;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<UserRole> Users { get; set; }
        public RoleType RoleType { get; set; }

        public SelectList RoleTypeList
        {
            get
            {
                var roleType = Enum.GetNames(typeof(RoleType)).ToList();
                return new SelectList(roleType);
            }
        }
    }


}