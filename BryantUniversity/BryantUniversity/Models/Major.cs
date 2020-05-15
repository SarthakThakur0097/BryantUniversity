namespace BryantUniversity.Models
{
    public class Major
    {
        public Major() { }

        public int Id { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}