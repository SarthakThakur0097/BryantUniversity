namespace BryantUniversity.Models
{
    public class Minor
    {
        public Minor(){ }

        public Minor(string title, int departmentId)
        {
            Title = title;
            DepartmentId = departmentId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}