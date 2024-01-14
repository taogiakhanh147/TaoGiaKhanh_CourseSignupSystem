using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _iSubjectService;

        public SubjectController(ISubjectService iSubjectService)
        {
            _iSubjectService = iSubjectService;
        }

        // Function GetAllSubject (GET)
        [HttpGet("GetAllSubject")]
        public async Task<IActionResult> GetAllSubject()
        {
            var subjects = await _iSubjectService.GetAllSubjectAsync();
            return Ok(subjects);
        }

        // Function GetSubjectById (GET)
        [HttpGet("GetSubjectById/{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            var subject = await _iSubjectService.GetSubjectsByIdAsync(id);
            return Ok(subject);
        }

        // Function AddNewSubject (POST)
        [HttpPost("AddNewSubject")]
        public async Task<IActionResult> AddNewSubject(SubjectDTO subjectDTO)
        {
            var newSubject = await _iSubjectService.AddSubjectAsync(subjectDTO);
            return Ok(newSubject);
        }

        // Function UpdateSubject (PUT)
        [HttpPut("UpdateSubject/{id}")]
        public async Task<IActionResult> UpdateSubject(int id, SubjectDTO subjectDTO)
        {
            var updateSubject = await _iSubjectService.UpdateSubjectAsync(id, subjectDTO);
            return Ok(updateSubject);
        }

        // Function DeleteSubject (DELETE)
        [HttpDelete("DeleteSubject/{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            await _iSubjectService.DeleteSubjectAsync(id);
            return Ok();
        }
    }
}
