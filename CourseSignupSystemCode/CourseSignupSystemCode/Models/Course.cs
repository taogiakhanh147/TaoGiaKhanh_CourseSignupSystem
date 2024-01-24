using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public int ID { get; set; }

        public string? CourseNO { get; set; }

        public string? CourseName { get; set; }

        public DateTime? CourseStartDate { get; set; }

        public DateTime? CourseEndDate { get; set; }

        [JsonIgnore]
        public ICollection<Class> Classes { get; set; }
    }
}
