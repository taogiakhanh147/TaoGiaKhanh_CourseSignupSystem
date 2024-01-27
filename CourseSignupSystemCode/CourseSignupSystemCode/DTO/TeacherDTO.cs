using System.ComponentModel.DataAnnotations;

namespace CourseSignupSystemCode.DTO
{
    public class TeacherDTO
    {
        public string? TaxCode { get; set; }

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

        public string? PartTimeSubject { get; set; }

        public string? Password { get; set; }

        [Required]
        public int IDSubject { get; set; }

        [Required]
        public int IDRole { get; set; }
    }
}
