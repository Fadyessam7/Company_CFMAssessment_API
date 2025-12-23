using Company_CFM.DTOs;

namespace Company_CFM.Services
{
    public interface ISalaryService
    {
        Task<List<SalarySumDto>> GetSumOfEmployeesSalariesByDepartment();
    }
}
