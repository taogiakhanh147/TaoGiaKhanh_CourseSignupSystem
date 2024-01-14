using CourseSignupSystemCode.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.DTO
{
    public class ScheduleDTO
    {
        public string? ClassRoom { get; set; }

        public string? StudyTime { get; set; }

        public string? StudyDay { get; set; }

        public string? Stage { get; set; }

        [Required]
        public int IDSubject { get; set; }

        [Required]
        public int IDStudent { get; set; }
    }
}
