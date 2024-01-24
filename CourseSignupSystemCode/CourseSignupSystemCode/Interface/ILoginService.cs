using CourseSignupSystemCode.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemCode.Interface
{
    public interface ILoginService
    {
        Task<IActionResult> GenerateJwtToken(LoginDTO jwtDTO);
    }
}
