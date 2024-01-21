using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
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
        public async Task<IActionResult> GetAllResult()
        {
            var results = await _iResultService.GetAllResultAsync();
            return Ok(results);
        }

        // Function GetResultById (GET)
        [HttpGet("GetResultById/{id}")]
        public async Task<IActionResult> GetResultById(int id)
        {
            var result = await _iResultService.GetResultsByIdAsync(id);
            return Ok(result);
        }

        // Function AddNewResult (POST)
        [HttpPost("AddNewResult")]
        public async Task<IActionResult> AddNewResult(ResultDTO resultDTO)
        {
            var newResult = await _iResultService.AddResultAsync(resultDTO);
            return Ok(newResult);
        }

        // Function UpdateResult (PUT)
        [HttpPut("UpdateResult/{id}")]
        public async Task<IActionResult> UpdateResult(int id, ResultDTO resultDTO)
        {
            var updateResult = await _iResultService.UpdateResultAsync(id, resultDTO);
            return Ok(updateResult);
        }

        // Function DeleteResult (DELETE)
        [HttpDelete("DeleteResult/{id}")]
        public async Task<IActionResult> DeleteResult(int id)
        {
            await _iResultService.DeleteResultAsync(id);
            return Ok();
        }
    }
}
