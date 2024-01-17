using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    public class SubjectOfTeacher
    {
        [Key]
        public int ID { get; set; }

        public string? SubjectNO { get; set; }

        public string? SubjectName { get; set; }

        [ForeignKey("Department")]
        public int IDDepartment { get; set; }

        [JsonIgnore]
        public Department Department { get; set; }

        [ForeignKey("Class")]
        public int IDClass { get; set; }

        [JsonIgnore]
        public Class Class { get; set; }

        [JsonIgnore]
        public ICollection<Teacher> Teachers { get; set; }
    }
}
