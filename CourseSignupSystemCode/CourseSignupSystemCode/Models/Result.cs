using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("Result")]
    public class Result
    {
        [Key]
        public int ID { get; set; }

        public float? Score { get; set; }

        [Required]
        public int IDSubject { get; set; }

        [Required]
        public int IDScoreType { get; set; }

        [ForeignKey("Student")]
        public int IDStudent { get; set; }

        [JsonIgnore]
        public Student Student { get; set; }
    }
}
