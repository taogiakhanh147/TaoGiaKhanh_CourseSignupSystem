using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int ID { get; set; }

        public string? LastName { get; set; }

        public string? MiddleAndFirstName { get; set; }

        public DateTime? Date { get; set; }

        public string? Sex { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? FullNameOfParent { get; set; }

        public string? Password { get; set; }

        public string? Image { get; set; }

        [ForeignKey("Role")]
        public int IDRole {  get; set; }

        [JsonIgnore]
        public Role Role { get; set; }

        [ForeignKey("Class")]
        public int IDClass { get; set; }

        [JsonIgnore]
        public Class Class { get; set; }

        [JsonIgnore]
        public ICollection<Schedule> Schedules { get; set; }

        [JsonIgnore]
        public ICollection<Tuition> Tuitions { get; set; }

        [JsonIgnore]
        public ICollection<Result> Results { get; set; }
    }
}
