using Company_CFM.DTOs;
using Company_CFM.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company_CFM.Controllers
{
    [ApiController]
    [Route("api/salary-sum")]
    public class Salary_SumController : ControllerBase
    {
        private readonly ISalaryService _salaryService;
        public Salary_SumController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SalarySumDto>>> GetSumOfEmployeesSalariesByDepartment()
        {
            var result = await _salaryService.GetSumOfEmployeesSalariesByDepartment();
            return Ok(result);
        }
    }
}
