using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _iTeacherService;

        public TeacherController(ITeacherService iTeacherService)
        {
            _iTeacherService = iTeacherService;
        }

        // Function GetAllTeacher (GET)
        [HttpGet("GetAllTeacher")]
        public async Task<IActionResult> GetAllTeacher()
        {
            var teachers = await _iTeacherService.GetAllTeacherAsync();
            return Ok(teachers);
        }

        // Function GetTeacherById (GET)
        [HttpGet("GetTeacherById/{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var teacher = await _iTeacherService.GetTeacherByIdAsync(id);
            return Ok(teacher);
        }

        // Function AddNewTeacher (POST)
        [HttpPost("AddNewTeacher")]
        public async Task<IActionResult> AddNewTeacher(TeacherDTO TeacherDTO)
        {
            var newTeacher = await _iTeacherService.AddTeacherAsync(TeacherDTO);
            return Ok(newTeacher);
        }

        // Function UploadImageTeacher (POST)
        [HttpPost("UploadImageTeacher/{id}")]
        public async Task<IActionResult> UploadImageTeacher(int id, IFormFile file)
        {
            var newTeacher = await _iTeacherService.UploadImageTeacherAsync(id, file);
            return Ok(newTeacher);
        }

        // Function UpdateTeacher (PUT)
        [HttpPut("UpdateTeacher/{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, TeacherDTO TeacherDTO)
        {
            var updateTeacher = await _iTeacherService.UpdateTeacherAsync(id, TeacherDTO);
            return Ok(updateTeacher);
        }

        // Function UpdateImageTeacher (PUT)
        [HttpPut("UpdateImageTeacher/{id}")]
        public async Task<IActionResult> UpdateImageTeacher(int id, IFormFile file)
        {
            var updateImageTeacher = await _iTeacherService.UpdateImageTeacherAsync(id, file);
            return Ok(updateImageTeacher);
        }

        // Function DeleteTeacher (DELETE)
        [HttpDelete("DeleteTeacher/{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            await _iTeacherService.DeleteTeacherAsync(id);
            return Ok();
        }
    }
}
