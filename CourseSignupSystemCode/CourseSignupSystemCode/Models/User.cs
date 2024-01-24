using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string? UserName { get; set; }

        public string? EMail { get; set; }

        public string? Password { get; set; }

        public string? Ịmage { get; set; }

        [ForeignKey("Role")]
        public int IDRole { get; set; }

        [JsonIgnore]
        public Role Role { get; set; }
    }

    public class Jwt
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}
