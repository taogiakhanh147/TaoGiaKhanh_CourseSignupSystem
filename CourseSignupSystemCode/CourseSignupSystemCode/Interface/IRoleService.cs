using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface IRoleService
    {
        public Task<List<Role>> GetAllRoleAsync();

        public Task<Role> GetRolesByIdAsync(int id);

        public Task<Role> AddRoleAsync(RoleDTO roleDTO);

        public Task<Role> UpdateRoleAsync(int id, RoleDTO roleDTO);

        public Task DeleteRoleAsync(int id);
    }
}
