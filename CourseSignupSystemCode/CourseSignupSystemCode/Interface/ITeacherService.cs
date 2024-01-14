using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface ITeacherService
    {
        public Task<List<Teacher>> GetAllTeacherAsync();

        public Task<Teacher> GetTeacherByIdAsync(int id);

        public Task<Teacher> AddTeacherAsync(TeacherDTO TeacherDTO);

        public Task<Teacher> UploadImageTeacherAsync(int id, IFormFile file);

        public Task<Teacher> UpdateTeacherAsync(int id, TeacherDTO TeacherDTO);

        public Task<Teacher> UpdateImageTeacherAsync(int id, IFormFile file);

        public Task DeleteTeacherAsync(int id);
    }
}
