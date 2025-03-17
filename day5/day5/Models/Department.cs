namespace day5.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<Employee> Employee { get; set; } = new List<Employee>();
    }
}