using Assignment1_PROG3340.Data;
using Microsoft.AspNetCore.Mvc;
using Assignment1_PROG3340.Data;
using Assignment1_PROG3340.Models;
using Microsoft.AspNetCore.Http;

namespace Assignment1_PROG3340
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET /api/employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Test Alice", Department = "Tester" },
                new Employee { Id = 2, Name = "Test Bob", Department = "Developer" }
            };

            return Ok(employees);
            // return await _context.Employees.ToListAsync();
        }
    }
}