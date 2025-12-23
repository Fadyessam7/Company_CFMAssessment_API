using Company_CFM.DTOs;

namespace Company_CFM.Repositories
{
    public interface ISalaryRepository
    {
        Task<List<SalarySumDto>> GetSumOfEmployeesSalariesByDepartment();
    }
}
