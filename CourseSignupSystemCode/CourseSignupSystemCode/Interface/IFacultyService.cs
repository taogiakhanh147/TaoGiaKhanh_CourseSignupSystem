using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface IFacultyService
    {
        public Task<List<Faculty>> GetAllFacultyAsync();

        public Task<Faculty> GetFacultysByIdAsync(int id);

        public Task<Faculty> AddFacultyAsync(FacultyDTO facultyDTO);

        public Task<Faculty> UpdateFacultyAsync(int id, FacultyDTO facultyDTO);

        public Task DeleteFacultyAsync(int id);
    }
}
