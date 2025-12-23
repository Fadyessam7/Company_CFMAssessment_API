using Company_CFM.DTOs;
using Company_CFM.Repositories;

namespace Company_CFM.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public async Task<List<CustomerDto>> GetAllCustomersWithOrders()
        {
            var customers = await _customerRepo.GetAllCustomerWithOrders();
            return customers.Select(c => new CustomerDto
            {
                Customer_Id = c.ID,
                Customer_Name = c.Name,
                Orders = c.Orders.Select(o => new OrderDto
                {
                    Order_Id = o.ID,
                    Amount = o.Amount ?? 0 , // Nullable
                    Product_Name = o.Product.Name ?? String.Empty,
                    Total_Cost = (o.Product?.Cost ?? 0) * o.Amount ?? 0 // Nullable
                }).ToList()
            }).ToList();
        }
    }
}
