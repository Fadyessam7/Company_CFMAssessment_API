using Company_CFM.DTOs;
using Company_CFM.Repositories;

namespace Company_CFM.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepository = orderRepo;
        }
        public async Task<List<OrderWithProductsNamesDto>> GetAllOrdersWithProductsNames()
        {
            var orders = await _orderRepository.GetAllOrdersWithProductsNames();
            return orders.Select(o => new OrderWithProductsNamesDto
            {
                Order_Id = o.ID,
                Product_Id = o.Product.ID,
                Product_Name = o.Product.Name
            }).ToList();
        }
    }
}
