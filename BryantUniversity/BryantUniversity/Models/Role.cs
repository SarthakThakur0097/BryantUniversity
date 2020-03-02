namespace BryantUniversity.Models
{
    public class Role
    {
        public Role() { }

        public Role(string roleName)
        {
            RoleName = roleName;
        }

        public int Id { get; set;}
        public string RoleName { get; set; }
    }
}