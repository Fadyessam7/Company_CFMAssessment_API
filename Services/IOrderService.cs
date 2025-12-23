namespace Company_CFM.Services
{
    public interface IOrderService
    {
        Task<List<DTOs.OrderWithProductsNamesDto>> GetAllOrdersWithProductsNames();
    }
}
