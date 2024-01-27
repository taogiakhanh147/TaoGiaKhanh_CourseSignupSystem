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
    public class ScoreTypeController : ControllerBase
    {
        private readonly IScoreTypeService _iScoreTypeService;

        public ScoreTypeController(IScoreTypeService iScoreTypeService)
        {
            _iScoreTypeService = iScoreTypeService;
        }

        // Function GetAllScoreType (GET)
        [HttpGet("GetAllScoreType")]
        public async Task<IActionResult> GetAllScoreType()
        {
            var scoreTypes = await _iScoreTypeService.GetAllScoreTypeAsync();
            return Ok(scoreTypes);
        }

        // Function GetScoreTypeById (GET)
        [HttpGet("GetScoreTypeById/{id}")]
        public async Task<IActionResult> GetScoreTypeById(int id)
        {
            var scoreType = await _iScoreTypeService.GetScoreTypesByIdAsync(id);
            return Ok(scoreType);
        }

        // Function AddNewScoreType (POST)
        [HttpPost("AddNewScoreType")]
        public async Task<IActionResult> AddNewScoreType(ScoreTypeDTO scoreTypeDTO)
        {
            var newScoreType = await _iScoreTypeService.AddScoreTypeAsync(scoreTypeDTO);
            return Ok(newScoreType);
        }

        // Function UpdateScoreType (PUT)
        [HttpPut("UpdateScoreType/{id}")]
        public async Task<IActionResult> UpdateScoreType(int id, ScoreTypeDTO scoreTypeDTO)
        {
            var updateScoreType = await _iScoreTypeService.UpdateScoreTypeAsync(id, scoreTypeDTO);
            return Ok(updateScoreType);
        }

        // Function DeleteScoreType (DELETE)
        [HttpDelete("DeleteScoreType/{id}")]
        public async Task<IActionResult> DeleteScoreType(int id)
        {
            await _iScoreTypeService.DeleteScoreTypeAsync(id);
            return Ok();
        }
    }
}
