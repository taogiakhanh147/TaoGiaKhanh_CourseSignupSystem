using CourseSignupSystemCode.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.DTO
{
    public class StudentDTO
    {
        public string? LastName { get; set; }

        public string? MiddleAndFirstName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public string? Sex { get; set; }

        [EmailAddress]
        [CustomEmailValidation(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? FullNameOfParent { get; set; }

        public string? Password { get; set; }

        [Required]
        public int IDRole { get; set; }

        [Required]
        public int IDClass { get; set; }
    }
}
