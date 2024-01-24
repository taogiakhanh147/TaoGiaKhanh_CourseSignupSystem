using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("ScoreTypeSubject")]
    public class ScoreTypeSubject
    {
        [Key]
        public int ID { get; set; }

        public int? GradingColumn { get; set; }

        public int? RequiredGradeColumns { get; set; }

        [Required]
        public int IDCourse { get; set; }

        [ForeignKey("SubjectOfStudent")]
        public int IDSubject { get; set; }

        [JsonIgnore]
        public SubjectOfStudent SubjectOfStudent { get; set; }

        [ForeignKey("ScoreType")]
        public int IDScoreType { get; set; }

        [JsonIgnore]
        public ScoreType ScoreType { get; set; }
    }
}
