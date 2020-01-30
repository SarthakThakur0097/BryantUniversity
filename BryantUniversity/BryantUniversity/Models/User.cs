using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BryantUniversity.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string HashedPassword { get; set; }
        [Required]
        public string Name { get; set; }

        public User()
        {

        }

        public User(string email, string passWord)
        {
            Email = email;
            HashedPassword = passWord;
        }
    }
}