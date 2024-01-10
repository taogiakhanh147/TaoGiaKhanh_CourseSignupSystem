using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("TuitionType")]
    public class TuitionType
    {
        [Key]
        public int ID { get; set; }

        public string? TuitionTypeName { get; set; }

        [JsonIgnore]
        public ICollection<Tuition> Tuitions { get; set; }
    }
}
