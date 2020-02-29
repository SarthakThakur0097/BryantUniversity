using BryantUniversity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BryantUniversity.Models;

namespace BryantUniversity.Models.Repo
{
    public class UserRepo
    {
        private Context _context;

        public UserRepo(Context context)
        {
            _context = context;
        }

        public IList<User> GetAllUsers()
        {
            return _context.Users.ToList();

        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(c => c.Id == id);
        }

        //public User GetByIdAndRole(int id, string role)
        //{

        //    return _context.Users.Join(
        //    _context.UserRoles,
        //    user => user.Id,
        //    usersRole => usersRole.UserId,
        //    (user, usersRole) => new
        //    {
        //        //userId = user.Id.
        //        //roleName = user.Name

        //    }).ToList();
        //}

        public User GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(c => c.Email == email);
        }
        public void Insert(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}