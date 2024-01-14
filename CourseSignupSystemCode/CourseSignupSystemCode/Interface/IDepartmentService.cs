using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface IDepartmentService
    {
        public Task<List<Department>> GetAllDepartmentAsync();

        public Task<Department> GetDepartmentsByIdAsync(int id);

        public Task<Department> AddDepartmentAsync(DepartmentDTO departmentDTO);

        public Task<Department> UpdateDepartmentAsync(int id, DepartmentDTO departmentDTO);

        public Task DeleteDepartmentAsync(int id);
    }
}
