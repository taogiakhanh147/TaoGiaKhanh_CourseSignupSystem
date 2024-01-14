using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _iCourseService;

        public CourseController(ICourseService iCourseService)
        {
            _iCourseService = iCourseService;
        }

        // Function GetAllCourse (GET)
        [HttpGet("GetAllCourse")]
        public async Task<IActionResult> GetAllCourse()
        {
            var courses = await _iCourseService.GetAllCourseAsync();
            return Ok(courses);
        }

        // Function GetCourseById (GET)
        [HttpGet("GetCourseById/{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _iCourseService.GetCoursesByIdAsync(id);
            return Ok(course);
        }

        // Function AddNewCourse (POST)
        [HttpPost("AddNewCourse")]
        public async Task<IActionResult> AddNewCourse(CourseDTO courseDTO)
        {
            var newCourse = await _iCourseService.AddCourseAsync(courseDTO);
            return Ok(newCourse);
        }

        // Function UpdateCourse (PUT)
        [HttpPut("UpdateCourse/{id}")]
        public async Task<IActionResult> UpdateCourse(int id, CourseDTO courseDTO)
        {
            var updateCourse = await _iCourseService.UpdateCourseAsync(id, courseDTO);
            return Ok(updateCourse);
        }

        // Function DeleteCourse (DELETE)
        [HttpDelete("DeleteCourse/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _iCourseService.DeleteCourseAsync(id);
            return Ok();
        }
    }
}
