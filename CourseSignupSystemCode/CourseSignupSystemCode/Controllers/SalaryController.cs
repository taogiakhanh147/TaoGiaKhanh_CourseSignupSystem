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
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _iSalaryService;

        public SalaryController(ISalaryService iSalaryService)
        {
            _iSalaryService = iSalaryService;
        }

        // Function GetAllSalary (GET)
        [HttpGet("GetAllSalary")]
        public async Task<IActionResult> GetAllSalary()
        {
            var salaries = await _iSalaryService.GetAllSalaryAsync();
            return Ok(salaries);
        }

        // Function GetSalaryById (GET)
        [HttpGet("GetSalaryById/{id}")]
        public async Task<IActionResult> GetSalaryById(int id)
        {
            var salary = await _iSalaryService.GetSalarysByIdAsync(id);
            return Ok(salary);
        }

        // Function AddNewSalary (POST)
        [HttpPost("AddNewSalary")]
        public async Task<IActionResult> AddNewSalary(SalaryDTO salaryDTO)
        {
            var newSalary = await _iSalaryService.AddSalaryAsync(salaryDTO);
            return Ok(newSalary);
        }

        // Function UpdateSalary (PUT)
        [HttpPut("UpdateSalary/{id}")]
        public async Task<IActionResult> UpdateSalary(int id, SalaryDTO salaryDTO)
        {
            var updateSalary = await _iSalaryService.UpdateSalaryAsync(id, salaryDTO);
            return Ok(updateSalary);
        }

        // Function DeleteSalary (DELETE)
        [HttpDelete("DeleteSalary/{id}")]
        public async Task<IActionResult> DeleteSalary(int id)
        {
            await _iSalaryService.DeleteSalaryAsync(id);
            return Ok();
        }
    }
}
