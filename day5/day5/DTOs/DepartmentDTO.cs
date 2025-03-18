namespace day5.DTOs
{
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
    }
}
