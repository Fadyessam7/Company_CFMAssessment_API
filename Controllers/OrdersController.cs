using Company_CFM.DTOs;
using Company_CFM.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company_CFM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService service)
        {
            _orderService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderWithProductsNamesDto>>> GetAllOrdersWithProductsNames()
        {
            var result = await _orderService.GetAllOrdersWithProductsNames();
            return Ok(result);
        }
    }
}
