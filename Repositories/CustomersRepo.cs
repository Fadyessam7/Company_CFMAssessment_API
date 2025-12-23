using Company_CFM.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_CFM.Repositories
{
    public class CustomersRepo : ICustomerRepository
    {
        private readonly CompanyDbContext _db;
        public CustomersRepo(CompanyDbContext db)
        {
            _db = db;
        }
        public async Task<List<Customers>> GetAllCustomerWithOrders()
        {
            return await _db.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.Product)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
