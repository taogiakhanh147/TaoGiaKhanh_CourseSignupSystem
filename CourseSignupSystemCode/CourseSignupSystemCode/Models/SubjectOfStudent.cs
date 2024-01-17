using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("Subject")]
    public class SubjectOfStudent
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

        /* [ForeignKey("Faculty")]
         public int IDFaculty { get; set; }

         [JsonIgnore]
         public Faculty Faculty { get; set; }*/

        [JsonIgnore]
        public ICollection<TeachingSchedule> TeachingSchedules { get; set; }

        [JsonIgnore]
        public ICollection<Schedule> Schedules { get; set; }

        [JsonIgnore]
        public ICollection<ScoreTypeSubject> ScoreTypeSubjects { get; set; }

       /* [JsonIgnore]
        public ICollection<Result> Results { get; set; }*/
    }
}
