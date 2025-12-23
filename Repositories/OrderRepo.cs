using Company_CFM.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_CFM.Repositories
{
    public class OrderRepo : IOrderRepository
    {
        private readonly CompanyDbContext _db;
        public OrderRepo(CompanyDbContext db)
        {
            _db = db;
        }
        public async Task<List<Orders>> GetAllOrdersWithProductsNames()
        {
            return await _db.Orders
                .Include(o => o.Product)
                .AsNoTracking()
                .OrderByDescending(o => o.ID)
                .ToListAsync();
        }
    }
}
