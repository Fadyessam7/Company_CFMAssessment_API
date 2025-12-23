using Company_CFM.DTOs;

namespace Company_CFM.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllCustomersWithOrders();
    }
}
