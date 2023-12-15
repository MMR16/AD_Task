using Core.DTO.Department;
using Core.DTO.Employee;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        [HttpGet]
        public ActionResult<IReadOnlyList<DepartmentToDisplayDto>> GeDepartments()
        {
            var dept = _departmentService.GetDepartments();
            return Ok(dept);
        }


        [HttpGet("{id:int}")]
        public ActionResult<DepartmentToDisplayDto> GetDepartmentById(int id)
        {
            var dept = _departmentService.GetDepartmentById(id);
            if (dept is not null)
            {
                return Ok(dept);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<AddDepartmentDto> AddDepartment(AddDepartmentDto department)
        {
          var result=  _departmentService.AddDepartment(department);
            if (result)
            {
            return StatusCode(StatusCodes.Status201Created);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        public ActionResult<UpdateDepartmentDto> UpdateDepartment(UpdateDepartmentDto department)
        {
            var result = _departmentService.UpdateDepartment(department);
            if (result)
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteDepartment(int id)
        {
            var result = _departmentService.DeleteDepartment(id);
            if (result is true)
            {
                return Ok();
            }
            return BadRequest();
        }


        [HttpGet("{departmentName}")]
        public ActionResult<int> GetDepartmentIdByName(string departmentName)
        {
            var deptId = _departmentService.GetDepartmentIdByDeptName(departmentName);
            if (deptId is not null)
            {
                return Ok(deptId);
            }
            return NotFound();
        }

        [HttpGet("details/{id:int}")]
        public ActionResult<DepartmentDetailsDto> GetDepartmentDetailsById(int id)
        {
            var dept = _departmentService.GetDepartmentFullDetails(id);
            if (dept is not null)
            {
                return Ok(dept);
            }
            return NotFound();
        }
    }
}
