using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using CourseSignupSystemCode.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _iStudentService;

        public StudentController(IStudentService iStudentService)
        {
            _iStudentService = iStudentService;
        }

        // Function GetAllStudent (GET)
        [HttpGet("GetAllStudent")]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await _iStudentService.GetAllStudentAsync();
            return Ok(students);
        }

        // Function GetStudentById (GET)
        [HttpGet("GetStudentById/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _iStudentService.GetStudentByIdAsync(id);
            return Ok(student);
        }

        // Function GetAllStudent (GET)
        [HttpGet("GetAllClassOfStudent/{email}/{idCourse}")]
        public async Task<IActionResult> GetAllClassOfStudent(string email, int idCourse)
        {
            var student = await _iStudentService.GetAllClassOfStudentAsync(email, idCourse);
            return Ok(student);
        }

        // Function AddNewStudent (POST)
        [HttpPost("AddNewStudent")]
        public async Task<IActionResult> AddNewStudent(StudentDTO studentDTO)
        {
            var newStudent = await _iStudentService.AddStudentAsync(studentDTO);
            return Ok(newStudent);
        }

        // Function UploadImageStudent (POST)
        [HttpPost("UploadImageStudent/{id}")]
        public async Task<IActionResult> UploadImageStudent(int id, IFormFile file)
        {
            var newStudent = await _iStudentService.UploadImageStudentAsync(id, file);
            return Ok(newStudent);
        }

        // Function UpdateStudent (PUT)
        [HttpPut("UpdateStudent/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentDTO studentDTO)
        {
            var updateStudent = await _iStudentService.UpdateStudentAsync(id, studentDTO);
            return Ok(updateStudent);
        }

        // Function UpdateImageStudent (PUT)
        [HttpPut("UpdateImageStudent/{id}")]
        public async Task<IActionResult> UpdateImageStudent(int id, IFormFile file)
        {
            var updateImageStudent = await _iStudentService.UpdateImageStudentAsync(id, file);
            return Ok(updateImageStudent);
        }

        // Function DeleteStudent (DELETE)
        [HttpDelete("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _iStudentService.DeleteStudentAsync(id);
            return Ok();
        }
    }
}
