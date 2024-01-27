using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystemCode.DTO
{
    public class SubjectOfStudentDTO
    {
        public string? SubjectNO { get; set; }

        public string? SubjectName { get; set; }

        [Required]
        public int IDDepartment { get; set; }


        [Required]
        public int IDClass { get; set; }
    }
}
