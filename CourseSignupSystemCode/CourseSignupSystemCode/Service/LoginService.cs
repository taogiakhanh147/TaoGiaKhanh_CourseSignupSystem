using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CourseSignupSystemCode.Service
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly CourseSignupSystemContext _context;

        public LoginService(IConfiguration configuration, CourseSignupSystemContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<IActionResult> GenerateJwtToken(LoginDTO loginDTO)
        {
            if (loginDTO != null && !string.IsNullOrEmpty(loginDTO.Email) && !string.IsNullOrEmpty(loginDTO.Password))
            {
                var userData = await GetUser(loginDTO.Email, loginDTO.Password);
                
                if (userData != null)
                {
                    var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                    var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Email", loginDTO.Email),
                        new Claim("Password", loginDTO.Password),
                    };

                    // Kiểm tra xem người dùng có quyền "Admin", "Giảng Viên", "Học Viên" hay không
                    if (userData.IDRole >= 1 && userData.IDRole <= 3)
                    {
                        var roleClaim = new Claim(ClaimTypes.Role, GetRoleName(userData.IDRole));
                        claims.Add(roleClaim);
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: signIn
                    );

                    return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return new BadRequestObjectResult("Invalid Credentials");
                }
            }
            else
            {
                return new BadRequestObjectResult("Invalid Credentials");
            }
        }

        private async Task<User> GetUser(string email, string password)
        {
            // Kiểm tra xem người dùng có tồn tại trong bảng User không
            var user = await _context.Users.FirstOrDefaultAsync(u => u.EMail == email && u.Password == password);
            if (user != null)
            {
                return user;
            }
            // Kiểm tra xem người dùng có tồn tại trong bảng Teacher không
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Email == email && t.Password == password);
            if (teacher != null)
            {
                return new User
                {
                    ID = teacher.ID,
                    UserName = teacher.MiddleAndFirstName,
                    EMail = teacher.Email,
                    Password = teacher.Password,
                    IDRole = teacher.IDRole
                };
            }
            // Kiểm tra xem người dùng có tồn tại trong bảng Student không
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Email == email && s.Password == password);
            if (student != null)
            {
                return new User
                {
                    ID = student.ID,
                    UserName = student.MiddleAndFirstName,
                    EMail = student.Email,
                    Password = student.Password,
                    IDRole = student.IDRole
                };
            }
            return null;
        }

        private string GetRoleName(int roleId)
        {
            switch (roleId)
            {
                case 1:
                    return "Admin";
                case 2:
                    return "Giảng viên";
                case 3:
                    return "Học Viên";
                default:
                    return string.Empty;
            }
        }
    }
}