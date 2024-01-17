using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _iHolidayService;

        public HolidayController(IHolidayService iHolidayService)
        {
            _iHolidayService = iHolidayService;
        }

        // Function GetAllHoliday (GET)
        [HttpGet("GetAllHoliday")]
        public async Task<IActionResult> GetAllHoliday()
        {
            var holidays = await _iHolidayService.GetAllHolidayAsync();
            return Ok(holidays);
        }

        // Function GetHolidayById (GET)
        [HttpGet("GetHolidayById/{id}")]
        public async Task<IActionResult> GetHolidayById(int id)
        {
            var holiday = await _iHolidayService.GetHolidaysByIdAsync(id);
            return Ok(holiday);
        }

        // Function AddNewHoliday (POST)
        [HttpPost("AddNewHoliday")]
        public async Task<IActionResult> AddNewHoliday(HolidayDTO holidayDTO)
        {
            var newHoliday = await _iHolidayService.AddHolidayAsync(holidayDTO);
            return Ok(newHoliday);
        }

        // Function UpdateHoliday (PUT)
        [HttpPut("UpdateHoliday/{id}")]
        public async Task<IActionResult> UpdateHoliday(int id, HolidayDTO holidayDTO)
        {
            var updateHoliday = await _iHolidayService.UpdateHolidayAsync(id, holidayDTO);
            return Ok(updateHoliday);
        }

        // Function DeleteHoliday (DELETE)
        [HttpDelete("DeleteHoliday/{id}")]
        public async Task<IActionResult> DeleteHoliday(int id)
        {
            await _iHolidayService.DeleteHolidayAsync(id);
            return Ok();
        }
    }
}
