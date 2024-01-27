using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace CourseSignupSystemCode.DTO
{
    public class GetAllInfoTeacherSalaryDTO
    {
        public int IdTeacher {  get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? SalaryNet { get; set; }
    }
}
