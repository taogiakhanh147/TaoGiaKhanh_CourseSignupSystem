using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _iResultService;

        public ResultController(IResultService iResultService)
        {
            _iResultService = iResultService;
        }

        // Function GetAllResult (GET)
        [HttpGet("GetAllResult")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllResult()
        {
            var results = await _iResultService.GetAllResultAsync();
            return Ok(results);
        }

        // Function GetResultById (GET)
        [HttpGet("GetResultById/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetResultById(int id)
        {
            var result = await _iResultService.GetResultsByIdAsync(id);
            return Ok(result);
        }

        // Function GetResultById (GET)
        [HttpGet("GetResultByStudent/{email}/{idCourse}")]
        [Authorize(Roles = "Admin, Học Viên")]
        public async Task<IActionResult> GetResultByStudent(string email, int idCourse)
        {
            var result = await _iResultService.GetResultByStudentAsync(email, idCourse);
            return Ok(result);
        }

        // Function AddNewResult (POST)
        [HttpPost("AddNewResult")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewResult(ResultDTO resultDTO)
        {
            var newResult = await _iResultService.AddResultAsync(resultDTO);
            return Ok(newResult);
        }

        // Function UpdateResult (PUT)
        [HttpPut("UpdateResult/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateResult(int id, ResultDTO resultDTO)
        {
            var updateResult = await _iResultService.UpdateResultAsync(id, resultDTO);
            return Ok(updateResult);
        }

        // Function DeleteResult (DELETE)
        [HttpDelete("DeleteResult/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteResult(int id)
        {
            await _iResultService.DeleteResultAsync(id);
            return Ok();
        }
    }
}
