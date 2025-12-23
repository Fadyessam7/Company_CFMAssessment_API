namespace Company_CFM.Services
{
    public interface IEmployeeService
    {
        Task<List<Company_CFM.DTOs.EmployeeDto>> GetAllEmployees();
    }
}
