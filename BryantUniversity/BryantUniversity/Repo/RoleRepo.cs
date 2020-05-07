using BryantUniversity.Data;
using BryantUniversity.Models;
using System.Collections.Generic;
using System.Linq;

namespace BryantUniversity.Repo
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
            return _context.Roles.FirstOrDefault(c => c.Id == id);
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