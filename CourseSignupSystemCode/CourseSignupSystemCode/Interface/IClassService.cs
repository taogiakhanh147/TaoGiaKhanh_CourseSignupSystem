using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface IClassService
    {
        public Task<List<Class>> GetAllClassAsync();

        public Task<Class> GetClassByIdAsync(int id);

        public Task<Class> AddClassAsync(ClassDTO classDTO);

        public Task<Class> UploadImageClassAsync(int id, IFormFile file);

        public Task<Class> UpdateClassAsync(int id, ClassDTO classDTO);

        public Task<Class> UpdateImageClassAsync(int id, IFormFile file);

        public Task DeleteClassAsync(int id);
    }
}
