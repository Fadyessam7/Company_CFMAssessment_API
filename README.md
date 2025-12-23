Project Overview
 ================
 - Purpose: ASP.NET Core Web API for Employees, Customers, Orders, and Salary.
 - Technologies: ASP.NET Core, Entity Framework Core, SQL Server, Swagger (OpenAPI).
 - Architecture: RESTful API with layered architecture (Controllers, Services, Repositories).
 - Endpoints: 
	GET/api/employees
	GET/api/customers
	GET/api/orders
	GET/api/salary-sum
---------------------------------------------------------------
Database Setup in MSSQL
 ==================
- Folder: Place all SQL scripts in the "SQL" folder.
- Run Order:
1. Create Database
2. Create Tables
3. Insert Data
---------------------------------------------------------------
EF Core scaffolding (from the database)
=========================
- Open terminal/command prompt.
- install ef core tools if not already installed:
   - dotnet tool install --global dotnet-ef
- install ef core sql server & tools provider if not already installed:
   - dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   - dotnet add package Microsoft.EntityFrameworkCore.Tools
- Scaffold the database:
   - dotnet ef dbcontext scaffold "Server=YOUR_SERVER_NAME;Database=Company;Trusted_Connection=True;MultipleActiveResultSets=True" Microsoft.EntityFrameworkCore.SqlServer -o Models -c CompanyDbContext --use-database-names
   - **replace YOUR_SERVER_NAME with your actual SQL Server name.**

- **What is the scaffolding command doing?**
- DbContext: Models/CompanyDbContext
- Entities: Models/Employees.cs, Models/Departments.cs, Models/Customers.cs, Models/Products.cs, Models/Orders.cs
- Relationships: Navigation properties based on our foreign keys
---------------------------------------------------------------
- How API Works
 ==================
- **Register DbContext and custom layers in Program.cs**
==========================

using Company_CFM.Repositories;
using Company_CFM.Services;

namespace Company_CFM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<Company_CFM.Models.CompanyDbContext>();
            // Employee Repository and Service
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepo>();
            // Customer Repository and Service
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerRepository, CustomersRepo>();
            // Order Repository and Service
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepo>();
            // Salary Repository and service
            builder.Services.AddScoped<ISalaryService, SalaryService>();
            builder.Services.AddScoped<ISalaryRepository, SalaryRepo>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
----------------------------------------------------------------
**Repository gets employees with departments:**
==========================

using Company_CFM.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_CFM.Repositories
{
    public class EmployeeRepo : IEmployeeRepository
    {
        private readonly CompanyDbContext _db;
        public EmployeeRepo(CompanyDbContext db)
        {
            _db = db;
        }
        public async Task<List<Employees>> GetAllEmployees()
        {
            return await _db.Employees
                .Include(e => e.Department)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
----------------------------------------------------------------

**Service maps Employee entities to Employee DTOs:**
==========================
using Company_CFM.DTOs;
using Company_CFM.Repositories;

namespace Company_CFM.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployees();
            return employees.Select(e => new EmployeeDto
            {
                ID = e.ID,
                Name = e.Name ?? String.Empty,
                Department_Name = e.Department.Name ?? String.Empty
            }).ToList();
        }
    }
}
----------------------------------------------------------------
 **Controller exposes the endpoint:**
 ==========================
 using Company_CFM.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company_CFM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }
    }
}
----------------------------------------------------------------

- **And another entity example - All Customers with orders, All Orders with Products Names, Sum of Employee Salaries By Department**


- Run and Test the API
 ==================
- Run the API
   1.dotnet run or use Visual Studio to start debugging (F5).
   2. Open a web browser and navigate to:
	  https://localhost:5001/swagger/index.html
	3. Use Swagger UI to test the endpoints.
	4. Example Endpoints:
	  - GET /api/employees => All employees with department name
	  - GET /api/customers => Customers with orders, product names, and total cost
	  - GET /api/orders => Orders with product names, descending by order ID
	  - GET /api/salary-sum => Sum of salaries per department

