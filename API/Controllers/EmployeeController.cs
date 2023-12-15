using Core.DTO.Employee;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<EmployeeToDisplayDto>> GetEmployees()
        {
            var emps = _employeeService.GetEmployees();

            return Ok(emps);
        }


        [HttpGet("{id:int}")]
        public ActionResult<EmployeeToDisplayDto> GetEmployeeById(int id)
        {
            var emp = _employeeService.GetEmployeeById(id);
            if (emp is not null)
            {
                return Ok(emp);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<AddEmployeeDto> AddEmployee(AddEmployeeDto employee)
        {
            var result = _employeeService.AddEmployee(employee);
            if (result)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        public ActionResult<UpdateEmployeeDto> UpdateEmployee(UpdateEmployeeDto employee)
        {
            var result = _employeeService.UpdateEmployee(employee);
            if (result)
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteEmployees(int id)
        {
            var result = _employeeService.DeleteEmployee(id);
            if (result is true)
            {
                return Ok();
            }
            return BadRequest();
        }


        [HttpGet("{managerName}")]
        public ActionResult<int> GetManagerIdByName(string managerName)
        {
            var managerId = _employeeService.GetManagerIdByManagerName(managerName);
            if (managerId is not null)
            {
                return Ok(managerId);
            }
            return NotFound();
        }


        [HttpGet("details/{id:int}")]
        public ActionResult<EmployeeDetailsDto> GetEmployeeDetailsById(int id)
        {
            var emp = _employeeService.GetEmployeeFullDetails(id);
            if (emp is not null)
            {
                return Ok(emp);
            }
            return NotFound();
        }
    }
}
