using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int ID { get; set; }

        public string? RoleName { get; set; }

        [JsonIgnore]
        public ICollection<User> Users { get; set; }

        [JsonIgnore]
        public ICollection<Teacher> Teachers { get; set; }

        [JsonIgnore]
        public ICollection<Student> Students { get; set; }
    }
}
