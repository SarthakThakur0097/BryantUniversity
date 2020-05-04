using BryantUniversity.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            return _context.Users
                .Include(u => u.UserRoles)
                .ToList();
        }

        public User GetById(int id)
        {
            return _context.Users
                .SingleOrDefault(c => c.Id == id);
        }

        public IList<User> GetUsersByRole(int roleId)
        {
            IList<User> students = _context.Users
                .Include(u => u.UserRoles)
                .Where(u => u.UserRoles.Any(r => r.RoleId == roleId))
                .ToList();

            _context.SaveChanges();

            return students;
        }

        public IList<User> GetAllFaculty()
        {
            IList<User> faculty = _context.Users
                .Include(u => u.UserRoles)
                .Where(u => u.UserRoles.Any(r => r.RoleId == 2))
                .ToList();
            _context.SaveChanges();

            return faculty;
        }


        public User GetByEmail(string email)
        {
            return _context.Users
                .SingleOrDefault(c => c.Email == email);
        }

        public void Insert(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}