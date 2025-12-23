using Company_CFM.DTOs;
using Company_CFM.Repositories;

namespace Company_CFM.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployees();
            return employees.Select(e => new EmployeeDto
            {
                ID = e.ID,
                Name = e.Name ?? String.Empty,
                Department_Name = e.Department.Name ?? String.Empty
            }).ToList();
        }
    }
}
