using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Học Viên")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _iScheduleService;

        public ScheduleController(IScheduleService iScheduleService)
        {
            _iScheduleService = iScheduleService;
        }

        // Function GetAllSchedule (GET)
        [HttpGet("GetAllSchedule")]
        public async Task<IActionResult> GetAllSchedule()
        {
            var schedules = await _iScheduleService.GetAllScheduleAsync();
            return Ok(schedules);
        }

        // Function GetScheduleById (GET)
        [HttpGet("GetScheduleById/{id}")]
        public async Task<IActionResult> GetScheduleById(int id)
        {
            var schedule = await _iScheduleService.GetSchedulesByIdAsync(id);
            return Ok(schedule);
        }

        // Function GetScheduleById (GET)
        [HttpGet("GetScheduleByEmail/{email}/{idCourse}")]
        public async Task<IActionResult> GetScheduleByEmail(string email, int idCourse)
        {
            var schedule = await _iScheduleService.GetScheduleByEmailAsync(email, idCourse);
            return Ok(schedule);
        }

        // Function AddNewSchedule (POST)
        [HttpPost("AddNewSchedule")]
        public async Task<IActionResult> AddNewSchedule(ScheduleDTO scheduleDTO)
        {
            var newSchedule = await _iScheduleService.AddScheduleAsync(scheduleDTO);
            return Ok(newSchedule);
        }

        // Function UpdateSchedule (PUT)
        [HttpPut("UpdateSchedule/{id}")]
        public async Task<IActionResult> UpdateSchedule(int id, ScheduleDTO scheduleDTO)
        {
            var updateSchedule = await _iScheduleService.UpdateScheduleAsync(id, scheduleDTO);
            return Ok(updateSchedule);
        }

        // Function DeleteSchedule (DELETE)
        [HttpDelete("DeleteSchedule/{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            await _iScheduleService.DeleteScheduleAsync(id);
            return Ok();
        }
    }
}
