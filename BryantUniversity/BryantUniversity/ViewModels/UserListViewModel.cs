using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BryantUniversity.ViewModels
{
    public class UserListViewModel
    {
        public IList<User> Users { get; set; }

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