using CourseSignupSystemCode.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.DTO
{
    public class SubjectOfTeacherDTO
    {
        public string? SubjectNO { get; set; }

        public string? SubjectName { get; set; }

        [Required]
        public int IDDepartment { get; set; }

        [Required]
        public int IDClass { get; set; }
    }
}
