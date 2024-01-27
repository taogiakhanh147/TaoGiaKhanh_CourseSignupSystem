using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("Class")]
    public class Class
    {
        [Key]
        public int ID { get; set; }

        public string? ClassNO { get; set; }

        public string? ClassName { get; set; }

        public int? NumberOfStudent { get; set; }

        public int? Fee { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        [ForeignKey("Course")]
        public int IDCourse { get; set; }

        [JsonIgnore]
        public Course Course { get; set; }

        [ForeignKey("Faculty")]
        public int IDFaculty { get; set; }

        [JsonIgnore]
        public Faculty Faculty { get; set; }

        [JsonIgnore]
        public ICollection<Student> Students { get; set; }

        [JsonIgnore]
        public ICollection<Salary> Salaries { get; set; }

        [JsonIgnore]
        public ICollection<SubjectOfStudent> SubjectOfStudents { get; set; }

        [JsonIgnore]
        public ICollection<SubjectOfTeacher> SubjectOfTeachers { get; set; }
    }
}
