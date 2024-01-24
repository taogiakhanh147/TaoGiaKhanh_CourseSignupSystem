using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Service;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllTeachingSchedule()
        {
            var teachingSchedules = await _iTeachingScheduleService.GetAllTeachingScheduleAsync();
            return Ok(teachingSchedules);
        }

        // Function GetTeachingScheduleById (GET)
        [HttpGet("GetTeachingScheduleById/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTeachingScheduleById(int id)
        {
            var teachingSchedule = await _iTeachingScheduleService.GetTeachingSchedulesByIdAsync(id);
            return Ok(teachingSchedule);
        }

        // Function GetScheduleById (GET)
        [HttpGet("GetScheduleByEmail/{email}/{idCourse}")]
        [Authorize(Roles = "Admin, Giảng Viên")]
        public async Task<IActionResult> GetScheduleByEmail(string email, int idCourse)
        {
            var schedule = await _iTeachingScheduleService.GetScheduleByEmailAsync(email, idCourse);
            return Ok(schedule);
        }

        // Function AddNewTeachingSchedule (POST)
        [HttpPost("AddNewTeachingSchedule")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewTeachingSchedule(TeachingScheduleDTO teachingScheduleDTO)
        {
            var newTeachingSchedule = await _iTeachingScheduleService.AddTeachingScheduleAsync(teachingScheduleDTO);
            return Ok(newTeachingSchedule);
        }

        // Function UpdateTeachingSchedule (PUT)
        [HttpPut("UpdateTeachingSchedule/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTeachingSchedule(int id, TeachingScheduleDTO teachingScheduleDTO)
        {
            var updateTeachingSchedule = await _iTeachingScheduleService.UpdateTeachingScheduleAsync(id, teachingScheduleDTO);
            return Ok(updateTeachingSchedule);
        }

        // Function DeleteTeachingSchedule (DELETE)
        [HttpDelete("DeleteTeachingSchedule/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTeachingSchedule(int id)
        {
            await _iTeachingScheduleService.DeleteTeachingScheduleAsync(id);
            return Ok();
        }
    }
}
