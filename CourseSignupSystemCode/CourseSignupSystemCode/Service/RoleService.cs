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

        public async Task<List<GetAllRolesAndInfoDTO>> GetAllRolesAndInfoAsync()
        {
            var list = new List<GetAllRolesAndInfoDTO>();
            // Trường hợp 1: Lấy thông tin từ bảng User và Role
            var user = await _context.Users
                     .Where(u => _context.Roles.Any(r => r.ID == u.IDRole))
                     .Select(u => new GetAllRolesAndInfoDTO
                     {
                         UserName = u.UserName,
                         Email = u.EMail,
                         RoleName = u.Role.RoleName
                     })
                     .ToListAsync();
            list.AddRange(user);
            // Trường hợp 2: Lấy thông tin từ bảng Teacher và Role
            var teacher = await _context.Teachers
                        .Where(t => _context.Roles.Any(r => r.ID == t.IDRole))
                        .Select(t => new GetAllRolesAndInfoDTO
                        {
                            UserName = t.LastName + " " + t.MiddleAndFirstName,
                            Email = t.Email,
                            RoleName = t.Role.RoleName
                        })
                        .ToListAsync();
            list.AddRange(teacher);
            // Trường hợp 3: Lấy thông tin từ bảng Student và Role
            var student = await _context.Students
                        .Where(s => _context.Roles.Any(r => r.ID == s.IDRole))
                        .Select(s => new GetAllRolesAndInfoDTO
                        {
                            UserName = s.LastName + " " + s.MiddleAndFirstName,
                            Email = s.Email,
                            RoleName = s.Role.RoleName
                        })
                        .ToListAsync();
            list.AddRange(student);
            // Loại bỏ các kết quả trùng lặp theo Email
            list = list.DistinctBy(x => x.Email).ToList();
            return list;
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
