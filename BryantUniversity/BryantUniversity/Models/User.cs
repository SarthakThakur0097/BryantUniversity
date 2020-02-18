using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BryantUniversity.Models
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }

        public User(string email, string passWord, string name) : base()
        {
            Email = email;
            HashedPassword = passWord;
            Name = name;
        }

        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string HashedPassword { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Role> Roles { get; set; }
    }
}