using CourseSignupSystemCode.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.DTO
{
    public class SalaryDTO
    {
        public int? SalaryPercent { get; set; }

        public int? Allowance { get; set; } // Tiền phụ cấp thêm (nếu có)

        public string? Note { get; set; }

        [JsonIgnore]
        public int? SalaryNet { get; set; } // Tiền cuối cùng giảng viên nhận được

        [Required]
        public int IDTeacher { get; set; }

        [Required]
        public int IDClass { get; set; }
    }
}
