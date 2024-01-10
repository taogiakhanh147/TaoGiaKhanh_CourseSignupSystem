using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("ScoreType")]
    public class ScoreType
    {
        [Key]
        public int ID { get; set; }

        public string? ScoreTypeName { get; set; }

        public int? ScoreScale { get; set; }

        [JsonIgnore]
        public ICollection<ScoreTypeSubject> ScoreTypeSubjects { get; set; }

       /* [JsonIgnore]
        public ICollection<Result> Results { get; set; }*/
    }
}
