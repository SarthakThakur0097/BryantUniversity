﻿using BryantUniversity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models.Repo
{
    public class UserRoleRepo
    {
        private Context _context;

        public UserRoleRepo(Context context)
        {
            _context = context;
        }

        public IList<UserRole> GetAllUserRoles(int id)
        {
            return _context.UserRoles.Where(c => c.Id == id).ToList();
        }

        public UserRole GetById(int id)
        {
            return _context.UserRoles.SingleOrDefault(c => c.Id == id);
        }

       
        public void Insert(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
        }

        public void Update(UserRole userRole)
        {
            _context.UserRoles.Attach(userRole);
            _context.Entry(userRole).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}