using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAllStudentAsync();

        public Task<Student> GetStudentByIdAsync(int id);

        public Task<Student> AddStudentAsync(StudentDTO studentDTO);

        public Task<Student> UploadImageStudentAsync(int id, IFormFile file);

        public Task<Student> UpdateStudentAsync(int id, StudentDTO studentDTO);

        public Task<Student> UpdateImageStudentAsync(int id, IFormFile file);

        public Task DeleteStudentAsync(int id);
    }
}
