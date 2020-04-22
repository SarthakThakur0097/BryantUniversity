using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using BryantUniversity.Models;
using System.Web.Mvc;
using System.ComponentModel;

namespace BryantUniversity.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<User> Users { get; set; }
        [Display(Name = "Role Type")]
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