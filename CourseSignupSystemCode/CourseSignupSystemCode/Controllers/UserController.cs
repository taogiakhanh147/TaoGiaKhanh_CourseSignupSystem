using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _iUserService;

        public UserController(IUserService iUserService)
        {
            _iUserService = iUserService;
        }

        // Function GetAllUser (GET)
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var Users = await _iUserService.GetAllUserAsync();
            return Ok(Users);
        }

        // Function GetUserById (GET)
        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var User = await _iUserService.GetUserByIdAsync(id);
            return Ok(User);
        }

        // Function AddNewUser (POST)
        [HttpPost("AddNewUser")]
        public async Task<IActionResult> AddNewUser(UserDTO UserDTO)
        {
            var newUser = await _iUserService.AddUserAsync(UserDTO);
            return Ok(newUser);
        }

        // Function UploadImageUser (POST)
        [HttpPost("UploadImageUser/{id}")]
        public async Task<IActionResult> UploadImageUser(int id, IFormFile file)
        {
            var newUser = await _iUserService.UploadImageUserAsync(id, file);
            return Ok(newUser);
        }

        // Function UpdateUser (PUT)
        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO UserDTO)
        {
            var updateUser = await _iUserService.UpdateUserAsync(id, UserDTO);
            return Ok(updateUser);
        }

        // Function UpdateImageUser (PUT)
        [HttpPut("UpdateImageUser/{id}")]
        public async Task<IActionResult> UpdateImageUser(int id, IFormFile file)
        {
            var updateImageUser = await _iUserService.UpdateImageUserAsync(id, file);
            return Ok(updateImageUser);
        }

        // Function DeleteUser (DELETE)
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _iUserService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
