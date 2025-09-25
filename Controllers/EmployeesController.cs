using Assignment1_PROG3340.Data;
using Assignment1_PROG3340.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1_PROG3340
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET /api/employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return Ok(_unitOfWork.Employees.GetAll());
        }
        
        // GET: /api/employees/{id}
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee  = _unitOfWork.Employees.GetById(id);
            if (employee == null) return NotFound();
            return employee;
        }
        
        // POST: api/employees
        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _unitOfWork.Employees.Add(employee);
            _unitOfWork.Complete();
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }
        
        // Put: api/employees/{id}
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();
            _unitOfWork.Employees.Update(employee);
            _unitOfWork.Complete();
            return Ok(employee);
        }
        
        // Delete: api/employees/{id}
        [HttpDelete("{id}")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            var employee = _unitOfWork.Employees.GetById(id);
            if (employee == null) return NotFound();
            _unitOfWork.Employees.Delete(employee);
            _unitOfWork.Complete();
            return employee;
        }
    }
}