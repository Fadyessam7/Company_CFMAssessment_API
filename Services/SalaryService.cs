using Company_CFM.DTOs;
using Company_CFM.Repositories;

namespace Company_CFM.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _salaryRepository;
        public SalaryService(ISalaryRepository salaryRepo)
        {
            _salaryRepository = salaryRepo;
        }
        public async Task<List<SalarySumDto>> GetSumOfEmployeesSalariesByDepartment()
        {
            return await _salaryRepository.GetSumOfEmployeesSalariesByDepartment();
        }
    }
}
