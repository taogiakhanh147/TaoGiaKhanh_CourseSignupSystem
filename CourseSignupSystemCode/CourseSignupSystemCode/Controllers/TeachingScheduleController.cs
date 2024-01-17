using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingScheduleController : ControllerBase
    {
        private readonly ITeachingScheduleService _iTeachingScheduleService;

        public TeachingScheduleController(ITeachingScheduleService iTeachingScheduleService)
        {
            _iTeachingScheduleService = iTeachingScheduleService;
        }

        // Function GetAllTeachingSchedule (GET)
        [HttpGet("GetAllTeachingSchedule")]
        public async Task<IActionResult> GetAllTeachingSchedule()
        {
            var teachingSchedules = await _iTeachingScheduleService.GetAllTeachingScheduleAsync();
            return Ok(teachingSchedules);
        }

        // Function GetTeachingScheduleById (GET)
        [HttpGet("GetTeachingScheduleById/{id}")]
        public async Task<IActionResult> GetTeachingScheduleById(int id)
        {
            var teachingSchedule = await _iTeachingScheduleService.GetTeachingSchedulesByIdAsync(id);
            return Ok(teachingSchedule);
        }

        // Function AddNewTeachingSchedule (POST)
        [HttpPost("AddNewTeachingSchedule")]
        public async Task<IActionResult> AddNewTeachingSchedule(TeachingScheduleDTO teachingScheduleDTO)
        {
            var newTeachingSchedule = await _iTeachingScheduleService.AddTeachingScheduleAsync(teachingScheduleDTO);
            return Ok(newTeachingSchedule);
        }

        // Function UpdateTeachingSchedule (PUT)
        [HttpPut("UpdateTeachingSchedule/{id}")]
        public async Task<IActionResult> UpdateTeachingSchedule(int id, TeachingScheduleDTO teachingScheduleDTO)
        {
            var updateTeachingSchedule = await _iTeachingScheduleService.UpdateTeachingScheduleAsync(id, teachingScheduleDTO);
            return Ok(updateTeachingSchedule);
        }

        // Function DeleteTeachingSchedule (DELETE)
        [HttpDelete("DeleteTeachingSchedule/{id}")]
        public async Task<IActionResult> DeleteTeachingSchedule(int id)
        {
            await _iTeachingScheduleService.DeleteTeachingScheduleAsync(id);
            return Ok();
        }
    }
}
