using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _iDepartmentService;

        public DepartmentController(IDepartmentService iDepartmentService)
        {
            _iDepartmentService = iDepartmentService;
        }

        // Function GetAllDepartment (GET)
        [HttpGet("GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var departments = await _iDepartmentService.GetAllDepartmentAsync();
            return Ok(departments);
        }

        // Function GetDepartmentById (GET)
        [HttpGet("GetDepartmentById/{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _iDepartmentService.GetDepartmentsByIdAsync(id);
            return Ok(department);
        }

        // Function AddNewDepartment (POST)
        [HttpPost("AddNewDepartment")]
        public async Task<IActionResult> AddNewDepartment(DepartmentDTO departmentDTO)
        {
            var newDepartment = await _iDepartmentService.AddDepartmentAsync(departmentDTO);
            return Ok(newDepartment);
        }

        // Function UpdateDepartment (PUT)
        [HttpPut("UpdateDepartment/{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentDTO departmentDTO)
        {
            var updateDepartment = await _iDepartmentService.UpdateDepartmentAsync(id, departmentDTO);
            return Ok(updateDepartment);
        }

        // Function DeleteDepartment (DELETE)
        [HttpDelete("DeleteDepartment/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _iDepartmentService.DeleteDepartmentAsync(id);
            return Ok();
        }
    }
}
