using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Harsh", Department = "DevOps" },
                new Employee { Id = 2, Name = "Ravi", Department = "Engineering" }
            };

            return Ok(employees);
        }
    }
}
