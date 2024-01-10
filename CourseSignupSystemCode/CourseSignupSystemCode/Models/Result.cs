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

        public int? Score { get; set; }

        [ForeignKey("Subject")]
        public int IDSubject { get; set; }

        /*[JsonIgnore]
        public Subject Subject { get; set; }*/

        /* [ForeignKey("ScoreType")]
         public int IDScoreType { get; set; }

         [JsonIgnore]
         public ScoreType ScoreType { get; set; }*/

        [ForeignKey("Student")]
        public int IDStudent { get; set; }

        [JsonIgnore]
        public Student Student { get; set; }
    }
}
