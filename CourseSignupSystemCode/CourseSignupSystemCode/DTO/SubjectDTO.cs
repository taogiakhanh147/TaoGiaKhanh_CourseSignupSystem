using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystemCode.DTO
{
    public class SubjectDTO
    {
        public string? SubjectNO { get; set; }

        public string? SubjectName { get; set; }

        [Required]
        public int IDDepartment { get; set; }

    }
}
