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

        [ForeignKey("Course")]
        public int IDCourse { get; set; }

       /* [JsonIgnore]
        public Course Course { get; set; }*/

        [ForeignKey("Subject")]
        public int IDSubject { get; set; }

        [JsonIgnore]
        public SubjectOfStudent Subject { get; set; }

        [ForeignKey("ScoreType")]
        public int IDScoreType { get; set; }

        [JsonIgnore]
        public ScoreType ScoreType { get; set; }
    }
}
