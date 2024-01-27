using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("Faculty")]
    public class Faculty
    {
        [Key]
        public int ID { get; set; }

        public string? FacultyName { get; set; }

       /* [JsonIgnore]
        public ICollection<Subject> Subjects { get; set; }*/

        [JsonIgnore]
        public ICollection<Class> Classes { get; set; }
    }
}
