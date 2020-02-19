using BryantUniversity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Models.Repo
{
    public class RoleRepo
    {
        private Context _context;

        public RoleRepo(Context context)
        {
            _context = context;
        }

        public IList<Role> GetAllUsers()
        {
            return _context.Roles.ToList();

        }

        public Role GetById(int id)
        {
            return _context.Roles.SingleOrDefault(c => c.Id == id);
        }

        public void Insert(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void Update(Role role)
        {
            _context.Roles.Attach(role);
            _context.Entry(role).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}