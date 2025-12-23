using Company_CFM.DTOs;
using Company_CFM.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company_CFM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomersWithOrders()
        {
            var result = await _service.GetAllCustomersWithOrders();
            return Ok(result);
        }
    }
}
