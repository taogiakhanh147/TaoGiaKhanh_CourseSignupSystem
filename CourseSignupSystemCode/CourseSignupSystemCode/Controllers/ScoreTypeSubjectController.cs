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
    public class ScoreTypeSubjectController : ControllerBase
    {
        private readonly IScoreTypeSubjectService _iScoreTypeSubjectService;

        public ScoreTypeSubjectController(IScoreTypeSubjectService iScoreTypeSubjectService)
        {
            _iScoreTypeSubjectService = iScoreTypeSubjectService;
        }

        // Function GetAllScoreTypeSubject (GET)
        [HttpGet("GetAllScoreTypeSubject")]
        public async Task<IActionResult> GetAllScoreTypeSubject()
        {
            var scoreTypeSubjects = await _iScoreTypeSubjectService.GetAllScoreTypeSubjectAsync();
            return Ok(scoreTypeSubjects);
        }

        // Function GetScoreTypeSubjectById (GET)
        [HttpGet("GetScoreTypeSubjectById/{id}")]
        public async Task<IActionResult> GetScoreTypeSubjectById(int id)
        {
            var scoreTypeSubject = await _iScoreTypeSubjectService.GetScoreTypeSubjectsByIdAsync(id);
            return Ok(scoreTypeSubject);
        }

        // Function AddNewScoreTypeSubject (POST)
        [HttpPost("AddNewScoreTypeSubject")]
        public async Task<IActionResult> AddNewScoreTypeSubject(ScoreTypeSubjectDTO scoreTypeSubjectDTO)
        {
            var newScoreTypeSubject = await _iScoreTypeSubjectService.AddScoreTypeSubjectAsync(scoreTypeSubjectDTO);
            return Ok(newScoreTypeSubject);
        }

        // Function UpdateScoreTypeSubject (PUT)
        [HttpPut("UpdateScoreTypeSubject/{id}")]
        public async Task<IActionResult> UpdateScoreTypeSubject(int id, ScoreTypeSubjectDTO scoreTypeSubjectDTO)
        {
            var updateScoreTypeSubject = await _iScoreTypeSubjectService.UpdateScoreTypeSubjectAsync(id, scoreTypeSubjectDTO);
            return Ok(updateScoreTypeSubject);
        }

        // Function DeleteScoreTypeSubject (DELETE)
        [HttpDelete("DeleteScoreTypeSubject/{id}")]
        public async Task<IActionResult> DeleteScoreTypeSubject(int id)
        {
            await _iScoreTypeSubjectService.DeleteScoreTypeSubjectAsync(id);
            return Ok();
        }
    }
}
