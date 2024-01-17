using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuitionTypeController : ControllerBase
    {
        private readonly ITuitionTypeService _iTuitionTypeService;

        public TuitionTypeController(ITuitionTypeService iTuitionTypeService)
        {
            _iTuitionTypeService = iTuitionTypeService;
        }

        // Function GetAllTuitionType (GET)
        [HttpGet("GetAllTuitionType")]
        public async Task<IActionResult> GetAllTuitionType()
        {
            var tuitionTypes = await _iTuitionTypeService.GetAllTuitionTypeAsync();
            return Ok(tuitionTypes);
        }

        // Function GetTuitionTypeById (GET)
        [HttpGet("GetTuitionTypeById/{id}")]
        public async Task<IActionResult> GetTuitionTypeById(int id)
        {
            var tuitionType = await _iTuitionTypeService.GetTuitionTypesByIdAsync(id);
            return Ok(tuitionType);
        }

        // Function AddNewTuitionType (POST)
        [HttpPost("AddNewTuitionType")]
        public async Task<IActionResult> AddNewTuitionType(TuitionTypeDTO tuitionTypeDTO)
        {
            var newTuitionType = await _iTuitionTypeService.AddTuitionTypeAsync(tuitionTypeDTO);
            return Ok(newTuitionType);
        }

        // Function UpdateTuitionType (PUT)
        [HttpPut("UpdateTuitionType/{id}")]
        public async Task<IActionResult> UpdateTuitionType(int id, TuitionTypeDTO tuitionTypeDTO)
        {
            var updateTuitionType = await _iTuitionTypeService.UpdateTuitionTypeAsync(id, tuitionTypeDTO);
            return Ok(updateTuitionType);
        }

        // Function DeleteTuitionType (DELETE)
        [HttpDelete("DeleteTuitionType/{id}")]
        public async Task<IActionResult> DeleteTuitionType(int id)
        {
            await _iTuitionTypeService.DeleteTuitionTypeAsync(id);
            return Ok();
        }
    }
}
