using CourseSignupSystemCode.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.DTO
{
    public class TeachingScheduleDTO
    {
        public string? ClassRoom { get; set; }

        public string? TeachTime { get; set; }

        public string? TeachDay { get; set; }

        public string? Stage { get; set; }

        [Required]
        public int IDClass { get; set; }

        [Required]
        public int IDSubject { get; set; }

        [Required]
        public int IDTeacher { get; set; }
    }
}
