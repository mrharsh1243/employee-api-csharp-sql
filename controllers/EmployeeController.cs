using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeeController : ControllerBase
    {
        // This list will reset each time app restarts (in-memory only)
        private static List<Employee> employees = new()
        {
            new Employee { Id = 1, Name = "Harsh", Department = "DevOps" },
            new Employee { Id = 2, Name = "Ravi", Department = "Engineering" }
        };

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return CreatedAtAction(nameof(GetEmployees), new { id = employee.Id }, employee);
        }
    }
}
