namespace BryantUniversity.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        //public User user { get; set; }
        //public Role role { get; set; }

        public UserRole() { }

        public UserRole(int userId, int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}