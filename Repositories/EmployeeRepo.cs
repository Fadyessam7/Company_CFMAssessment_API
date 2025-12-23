using Company_CFM.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_CFM.Repositories
{
    public class EmployeeRepo : IEmployeeRepository
    {
        private readonly CompanyDbContext _db;
        public EmployeeRepo(CompanyDbContext db)
        {
            _db = db;
        }
        public async Task<List<Employees>> GetAllEmployees()
        {
            return await _db.Employees
                .Include(e => e.Department)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
