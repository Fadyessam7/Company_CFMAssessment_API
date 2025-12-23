using Company_CFM.Models;

namespace Company_CFM.Repositories
{
    public interface IEmployeeRepository
    {
        //IEnumerable<Company_CFM.DTOs.EmployeeDto> GetAllEmployees();
        Task<List<Employees>> GetAllEmployees();
    }
}
