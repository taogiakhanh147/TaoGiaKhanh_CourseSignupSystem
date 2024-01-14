using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class UserService : IUserService
    {
        private readonly CourseSignupSystemContext _context;
        public UserService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            var users = await _context.Users.ToListAsync();
            if(users.Count == 0)
            {
                throw new NotImplementedException("User not data");
            }
            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null)
            {
                throw new NotImplementedException("User not exist");
            }
            return user;
        }

        public async Task<User> AddUserAsync(UserDTO userDTO)
        {
            if(userDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            var newUser = new User 
            { 
                UserName = userDTO.UserName,
                EMail = userDTO.EMail,
                Password = userDTO.Password,
                IDRole = userDTO.IDRole
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> UploadImageUserAsync(int id, IFormFile file)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.ID == id);
            if(existingUser == null)
            {
                throw new NotImplementedException("User not exist");
            }
            if(file != null)
            {
                existingUser.Ịmage = await SaveFile(file);
                await _context.SaveChangesAsync();
            }
            return existingUser;
        }

        public async Task<User> UpdateUserAsync(int id, UserDTO userDTO)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if(existingUser == null)
            {
                throw new NotImplementedException("User not exist");
            }
            existingUser.UserName = userDTO.UserName;
            existingUser.EMail = userDTO.EMail;
            existingUser.Password = userDTO.Password;
            existingUser.IDRole = userDTO.IDRole;
            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User> UpdateImageUserAsync(int id, IFormFile file)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.ID == id);
            if(existingUser == null)
            {
                throw new NotImplementedException("User not exist");
            }
            existingUser.Ịmage = await SaveFile(file);
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task DeleteUserAsync(int id)
        {
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.ID == id);
            if( existingUser == null)
            {
                throw new NotImplementedException("User not exist");
            }
            _context.Users.Remove(existingUser);
            await _context.SaveChangesAsync();

        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var filePath = Path.Combine("D:\\Alta SoftWare\\CourseSignupSystem\\CourseSignupSystemCode\\CourseSignupSystemCode\\Upload", file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;
        }
    }
}
