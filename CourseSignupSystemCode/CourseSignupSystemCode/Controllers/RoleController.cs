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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _iRoleService;

        public RoleController(IRoleService iRoleService)
        {
            _iRoleService = iRoleService;
        }

        // Function GetAllRole (GET)
        [HttpGet("GetAllRole")]
        public async Task<IActionResult> GetAllRole() 
        {
            var roles = await _iRoleService.GetAllRoleAsync();
            return Ok(roles);
        }

        // Function GetRoleById (GET)
        [HttpGet("GetRoleById/{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _iRoleService.GetRolesByIdAsync(id);
            return Ok(role);
        }

        // Function AddNewRole (POST)
        [HttpPost("AddNewRole")]
        public async Task<IActionResult> AddNewRole(RoleDTO roleDTO)
        {
            var newRole = await _iRoleService.AddRoleAsync(roleDTO);
            return Ok(newRole);
        }

        // Function UpdateRole (PUT)
        [HttpPut("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(int id, RoleDTO roleDTO)
        {
            var updateRole = await _iRoleService.UpdateRoleAsync(id, roleDTO);
            return Ok(updateRole);
        }

        // Function DeleteRole (DELETE)
        [HttpDelete("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _iRoleService.DeleteRoleAsync(id);
            return Ok();
        }
    }
}
