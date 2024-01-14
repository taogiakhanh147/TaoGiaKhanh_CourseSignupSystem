using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class RoleService : IRoleService
    {
        private readonly CourseSignupSystemContext _context;

        public RoleService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAllRoleAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            if(roles.Count == 0)
            {
                throw new NotImplementedException("Role not data");
            }
            return roles;
        }

        public async Task<Role> GetRolesByIdAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if(role == null)
            {
                throw new NotImplementedException("Role not exist");
            }
            return role;    
        }

        public async Task<Role> AddRoleAsync(RoleDTO roleDTO)
        {
            if(roleDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            var newRole = new Role
            {
                RoleName = roleDTO.RoleName
            };
            _context.Roles.Add(newRole);
            await _context.SaveChangesAsync();
            return newRole;
        }

        public async Task<Role> UpdateRoleAsync(int id, RoleDTO roleDTO)
        {
            var existingRole = await _context.Roles.FindAsync(id);
            if(existingRole == null)
            {
                throw new NotImplementedException("Role not exist");
            }
            existingRole.RoleName = roleDTO.RoleName;
            _context.Roles.Update(existingRole);
            await _context.SaveChangesAsync(); 
            return existingRole;
        }

        public async Task DeleteRoleAsync(int id)
        {
            var existingRole = await _context.Roles.SingleOrDefaultAsync(r => r.ID == id);
            if(existingRole == null)
            {
                throw new NotImplementedException("Role not exist");
            }
            _context.Roles.Remove(existingRole);
            await _context.SaveChangesAsync();
        }
    }
}
