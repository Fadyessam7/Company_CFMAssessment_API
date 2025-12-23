using Company_CFM.Models;

namespace Company_CFM.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Orders>> GetAllOrdersWithProductsNames();
    }
}
