using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int ID { get; set; }

        public string? DepartmentName { get; set; }

        [JsonIgnore]
        public ICollection<SubjectOfStudent> SubjectOfStudents { get; set; }

        [JsonIgnore]
        public ICollection<SubjectOfTeacher> SubjectOfTeachers { get; set; }
    }
}
