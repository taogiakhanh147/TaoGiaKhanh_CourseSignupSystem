using CourseSignupSystemCode.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.DTO
{
    public class UserDTO
    {
        public string? UserName { get; set; }

        [EmailAddress]
        [CustomEmailValidation(ErrorMessage = "Invalid Email Address")]
        public string? EMail { get; set; }

        public string? Password { get; set; }

        [Required]
        public int IDRole { get; set; }
    }
    public class CustomEmailValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string email = value as string;

            if (email != null)
            {
                // Kiểm tra xem email có thuộc tên miền @gmail.com không
                if (!email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
