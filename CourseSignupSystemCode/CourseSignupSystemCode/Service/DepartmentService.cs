using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly CourseSignupSystemContext _context;

        public DepartmentService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllDepartmentAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            if (departments.Count == 0)
            {
                throw new NotImplementedException("Department not data");
            }
            return departments;
        }

        public async Task<Department> GetDepartmentsByIdAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                throw new NotImplementedException("Department not exist");
            }
            return department;
        }

        public async Task<Department> AddDepartmentAsync(DepartmentDTO departmentDTO)
        {
            if (departmentDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            var newDepartment = new Department
            {
                DepartmentName = departmentDTO.DepartmentName
            };
            _context.Departments.Add(newDepartment);
            await _context.SaveChangesAsync();
            return newDepartment;
        }

        public async Task<Department> UpdateDepartmentAsync(int id, DepartmentDTO departmentDTO)
        {
            var existingDepartment = await _context.Departments.FindAsync(id);
            if (existingDepartment == null)
            {
                throw new NotImplementedException("Department not exist");
            }
            existingDepartment.DepartmentName = departmentDTO.DepartmentName;
            _context.Departments.Update(existingDepartment);
            await _context.SaveChangesAsync();
            return existingDepartment;
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var existingDepartment = await _context.Departments.SingleOrDefaultAsync(d => d.ID == id);
            if (existingDepartment == null)
            {
                throw new NotImplementedException("Department not exist");
            }
            _context.Departments.Remove(existingDepartment);
            await _context.SaveChangesAsync();
        }
    }
}
