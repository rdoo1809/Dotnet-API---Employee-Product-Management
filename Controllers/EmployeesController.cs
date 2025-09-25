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
            return Ok(_context.Employees.ToList());
        }
        
        // GET: /api/employees/{id}
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();
            return employee;
        }
        
        // POST: api/employees
        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }
        
        // Put: api/employees/{id}
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();
            _context.Entry(employee).State = EntityState.Modified; 
            _context.SaveChanges();
            return Ok(employee);
        }
        
        // Delete: api/employees/{id}
        [HttpDelete("{id}")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return employee;
        }
    }
}