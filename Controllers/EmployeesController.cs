using Assignment1_PROG3340.Data;
using Microsoft.AspNetCore.Mvc;
using Assignment1_PROG3340.Data;
using Assignment1_PROG3340.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

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
            // var employees = new List<Employee>
            // {
            //     new Employee { Id = 1, Name = "Test Alice", Department = "Tester" },
            //     new Employee { Id = 2, Name = "Test Bob", Department = "Developer" }
            // };

            Console.WriteLine($"DB Path: {Path.GetFullPath("app.db")}");
            return Ok(_context.Employees.ToList());
        }
        
        // GET: /api/employees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();
            return employee;
        }
    }
}