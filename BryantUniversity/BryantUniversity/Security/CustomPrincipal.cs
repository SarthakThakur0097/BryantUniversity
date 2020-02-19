using BryantUniversity.Models;
using System;
using System.Security.Principal;
using BryantUniversity.Models.Repo;
using BryantUniversity.Data;
using System.Collections.Generic;

namespace BryantUniversity.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity identity;
        private User user;
        private Context context;

        public CustomPrincipal(CustomIdentity identity, User user)
        {
            this.identity = identity;
            this.user = user;
            context = new Context();
        }

        public IIdentity Identity
        {
            get
            {
                return identity;
            }
        }

        public User User
        {
            get
            {
                return user;
            }
        }

        public bool IsInRole(string role)
        {
            int userId = User.Id;
            UserRoleRepo userRoleRepo = new UserRoleRepo(context);
            UserRole userRole = userRoleRepo.GetById(userId);
            List<Role> userRoles = user.Roles;

            for(int i = 0; i<userRoles.Count; i++)
            {
                if (userRoles[i].Equals(role))
                {
                    return true;
                }
            }

            return false;
        }
    }
}