using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("Schedule")]
    public class Schedule
    {
        [Key]
        public int ID { get; set; }

        public string? ClassRoom { get; set; }

        public string? StudyTime { get; set; }

        public string? StudyDay { get; set; }

        public string? Stage { get; set; }

        [ForeignKey("Subject")]
        public int IDSubject { get; set; }

        /*[JsonIgnore]
        public Subject Subject { get; set; }*/

        [ForeignKey("Student")]
        public int IDStudent { get; set; }

        [JsonIgnore]
        public Student Student { get; set; }
    }
}
