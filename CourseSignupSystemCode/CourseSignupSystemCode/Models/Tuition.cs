using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("Tuition")]
    public class Tuition
    {
        [Key]
        public int ID { get; set; }

        public int? TuitionFee { get; set; }

        public int? Discount { get; set; }

        public string? Note { get; set; }

        [ForeignKey("Class")]
        public int IDClass { get; set; }

        /*[JsonIgnore]
        public Class Class { get; set; }*/

        [ForeignKey("Student")]
        public int IDStudent { get; set; }

        [JsonIgnore]
        public Student Student { get; set; }

        [ForeignKey("TuitionType")]
        public int IDTuitionType { get; set; }

        [JsonIgnore]
        public TuitionType TuitionType { get; set; }
    }
}
