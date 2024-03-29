﻿using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _iClassService;

        public ClassController(IClassService iClassService)
        {
            _iClassService = iClassService;
        }

        // Function GetAllClass (GET)
        [HttpGet("GetAllClass")]
        [Authorize(Roles = "Admin, Giảng Viên, Học Viên")]
        public async Task<IActionResult> GetAllClass()
        {
            var Classs = await _iClassService.GetAllClassAsync();
            return Ok(Classs);
        }

        // Function GetClassById (GET)
        [HttpGet("GetClassById/{id}")]
        [Authorize(Roles = "Admin, Giảng Viên, Học Viên")]
        public async Task<IActionResult> GetClassById(int id)
        {
            var Class = await _iClassService.GetClassByIdAsync(id);
            return Ok(Class);
        }

        // Function GetClassById (GET)
        [HttpGet("GetAllStudentInClass/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllStudentInClass(int id)
        {
            var Class = await _iClassService.GetAllStudentInClassAsync(id);
            return Ok(Class);
        }

        // Function AddNewClass (POST)
        [HttpPost("AddNewClass")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewClass(ClassDTO classDTO)
        {
            var newClass = await _iClassService.AddClassAsync(classDTO);
            return Ok(newClass);
        }

        // Function UploadImageClass (POST)
        [HttpPost("UploadImageClass/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UploadImageClass(int id, IFormFile file)
        {
            var newClass = await _iClassService.UploadImageClassAsync(id, file);
            return Ok(newClass);
        }

        // Function UpdateClass (PUT)
        [HttpPut("UpdateClass/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateClass(int id, ClassDTO classDTO)
        {
            var updateClass = await _iClassService.UpdateClassAsync(id, classDTO);
            return Ok(updateClass);
        }

        // Function UpdateImageClass (PUT)
        [HttpPut("UpdateImageClass/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateImageClass(int id, IFormFile file)
        {
            var updateImageClass = await _iClassService.UpdateImageClassAsync(id, file);
            return Ok(updateImageClass);
        }

        // Function DeleteClass (DELETE)
        [HttpDelete("DeleteClass/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            await _iClassService.DeleteClassAsync(id);
            return Ok();
        }
    }
}
