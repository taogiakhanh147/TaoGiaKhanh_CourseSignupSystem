using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.Models
{
    [Table("Salary")]
    public class Salary
    {
        [Key]
        public int ID { get; set; }

        public int? SalaryPercent { get; set; }

        public int? Allowance { get; set; } // Tiền phụ cấp thêm (nếu có)

        public string? Note { get; set; }

        public int? SalaryNet { get; set; } // Tiền cuối cùng giảng viên nhận được

        [Required]
        public int IDTeacher { get; set; }

        [ForeignKey("Class")]
        public int IDClass { get; set; }

        [JsonIgnore]
        public Class Class { get; set; }
    }
}
