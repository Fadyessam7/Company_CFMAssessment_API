using Company_CFM.DTOs;
using Company_CFM.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_CFM.Repositories
{
    public class SalaryRepo : ISalaryRepository
    {
        private readonly CompanyDbContext _db;
        public SalaryRepo(CompanyDbContext db)
        {
            _db = db;
        }
        public async Task<List<SalarySumDto>> GetSumOfEmployeesSalariesByDepartment()
        {
            return await _db.Departments
                .Select(d => new SalarySumDto
                {
                    Department_Id = d.ID,
                    Department_Name = d.Name,
                    Sum_Salary = d.Employees.Sum(e => e.Salary ?? 0)
                }).ToListAsync();
        }
    }
}
