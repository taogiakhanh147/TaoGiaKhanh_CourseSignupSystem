using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface ISalaryService
    {
        public Task<List<Salary>> GetAllSalaryAsync();

        public Task<Salary> GetSalarysByIdAsync(int id);

        public Task<Salary> AddSalaryAsync(SalaryDTO salaryDTO);

        public Task<Salary> UpdateSalaryAsync(int id, SalaryDTO salaryDTO);

        public Task DeleteSalaryAsync(int id);
    }
}
