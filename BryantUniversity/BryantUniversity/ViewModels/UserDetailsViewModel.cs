using BryantUniversity.Models;
using System.Collections.Generic;

namespace BryantUniversity.ViewModels
{
    public class UserDetailsViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public List<Role> Roles { get; set; }
    }
}