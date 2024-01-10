using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("TeachingSchedule")]
    public class TeachingSchedule
    {
        [Key]
        public int ID { get; set; }

        public string? ClassRoom { get; set; }

        public string? TeachTime { get; set; }

        public string? TeachDay { get; set; }

        public string? Stage { get; set; }

        [ForeignKey("Class")]
        public int IDClass { get; set; }

        [JsonIgnore]
        public Class Class { get; set; }

        [ForeignKey("Subject")]
        public int IDSubject { get; set; }

        [JsonIgnore]
        public Subject Subject { get; set; }

        [ForeignKey("Teacher")]
        public int IDTeacher { get; set; }

        [JsonIgnore]
        public Teacher Teacher { get; set; }
    }
}
