using Company_CFM.Models;

namespace Company_CFM.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customers>> GetAllCustomerWithOrders();
    }
}
