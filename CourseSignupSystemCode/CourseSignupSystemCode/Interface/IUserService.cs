using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUserAsync();

        public Task<User> GetUserByIdAsync(int id);

        public Task<User> AddUserAsync(UserDTO userDTO);

        public Task<User> UploadImageUserAsync(int id, IFormFile file);

        public Task<User> UpdateUserAsync(int id, UserDTO userDTO);

        public Task<User> UpdateImageUserAsync(int id, IFormFile file);

        public Task DeleteUserAsync(int id);
    }
}
