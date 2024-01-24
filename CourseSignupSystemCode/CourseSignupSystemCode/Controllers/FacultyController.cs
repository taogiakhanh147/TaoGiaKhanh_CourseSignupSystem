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
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _iFacultyService;

        public FacultyController(IFacultyService iFacultyService)
        {
            _iFacultyService = iFacultyService;
        }

        // Function GetAllFaculty (GET)
        [HttpGet("GetAllFaculty")]
        public async Task<IActionResult> GetAllFaculty()
        {
            var faculties = await _iFacultyService.GetAllFacultyAsync();
            return Ok(faculties);
        }

        // Function GetFacultyById (GET)
        [HttpGet("GetFacultyById/{id}")]
        public async Task<IActionResult> GetFacultyById(int id)
        {
            var faculty = await _iFacultyService.GetFacultysByIdAsync(id);
            return Ok(faculty);
        }

        // Function AddNewFaculty (POST)
        [HttpPost("AddNewFaculty")]
        public async Task<IActionResult> AddNewFaculty(FacultyDTO facultyDTO)
        {
            var newFaculty = await _iFacultyService.AddFacultyAsync(facultyDTO);
            return Ok(newFaculty);
        }

        // Function UpdateFaculty (PUT)
        [HttpPut("UpdateFaculty/{id}")]
        public async Task<IActionResult> UpdateFaculty(int id, FacultyDTO facultyDTO)
        {
            var updateFaculty = await _iFacultyService.UpdateFacultyAsync(id, facultyDTO);
            return Ok(updateFaculty);
        }

        // Function DeleteFaculty (DELETE)
        [HttpDelete("DeleteFaculty/{id}")]
        public async Task<IActionResult> DeleteFaculty(int id)
        {
            await _iFacultyService.DeleteFacultyAsync(id);
            return Ok();
        }
    }
}
