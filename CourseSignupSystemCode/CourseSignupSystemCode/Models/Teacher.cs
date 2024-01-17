using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        public int ID { get; set; }

        public string? TaxCode { get; set; }

        public string? LastName { get; set; }   

        public string? MiddleAndFirstName { get; set;}

        public DateTime? Date { get; set; }

        public string? Sex { get; set;}

        public string? Email { get;  set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? PartTimeSubject { get; set; }

        public string? Password { get; set; }

        public string? Image { get; set; }

        [ForeignKey("SubjectOfTeacher")]
        public int IDSubject { get; set; }

        [JsonIgnore]
        public SubjectOfTeacher SubjectOfTeacher { get; set; }

        [ForeignKey("Role")]
        public int IDRole { get; set; }

        [JsonIgnore]
        public Role Role { get; set; }

        [JsonIgnore]
        public ICollection<TeachingSchedule> teachingSchedules { get; set; }

        /*[JsonIgnore]
        public ICollection<Salary> Salaries { get; set; }*/
    }
}
