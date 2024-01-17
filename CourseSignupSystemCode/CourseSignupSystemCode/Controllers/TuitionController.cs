using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuitionController : ControllerBase
    {
        private readonly ITuitionService _iTuitionService;

        public TuitionController(ITuitionService iTuitionService)
        {
            _iTuitionService = iTuitionService;
        }

        // Function GetAllTuition (GET)
        [HttpGet("GetAllTuition")]
        public async Task<IActionResult> GetAllTuition()
        {
            var tuitions = await _iTuitionService.GetAllTuitionAsync();
            return Ok(tuitions);
        }

        // Function GetTuitionById (GET)
        [HttpGet("GetTuitionById/{id}")]
        public async Task<IActionResult> GetTuitionById(int id)
        {
            var tuition = await _iTuitionService.GetTuitionsByIdAsync(id);
            return Ok(tuition);
        }

        // Function AddNewTuition (POST)
        [HttpPost("AddNewTuition")]
        public async Task<IActionResult> AddNewTuition(TuitionDTO tuitionDTO)
        {
            var newTuition = await _iTuitionService.AddTuitionAsync(tuitionDTO);
            return Ok(newTuition);
        }

        // Function UpdateTuition (PUT)
        [HttpPut("UpdateTuition/{id}")]
        public async Task<IActionResult> UpdateTuition(int id, TuitionDTO tuitionDTO)
        {
            var updateTuition = await _iTuitionService.UpdateTuitionAsync(id, tuitionDTO);
            return Ok(updateTuition);
        }

        // Function DeleteTuition (DELETE)
        [HttpDelete("DeleteTuition/{id}")]
        public async Task<IActionResult> DeleteTuition(int id)
        {
            await _iTuitionService.DeleteTuitionAsync(id);
            return Ok();
        }
    }
}
