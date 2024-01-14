using CourseSignupSystemCode.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.DTO
{
    public class ClassDTO
    {
        public string? ClassNO { get; set; }

        public string? ClassName { get; set; }

        public int? NumberOfStudent { get; set; }

        public int? Fee { get; set; }

        public string? Description { get; set; }

        [Required]
        public int IDCourse { get; set; }

        [Required]
        public int IDFaculty { get; set; }
    }
}
