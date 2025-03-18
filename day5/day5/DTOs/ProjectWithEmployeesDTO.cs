namespace day5.DTOs
{
    public class ProjectWithEmployeesDTO
    {
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public List<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();
    }
}
