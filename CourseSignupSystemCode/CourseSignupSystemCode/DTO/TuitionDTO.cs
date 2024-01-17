using CourseSignupSystemCode.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.DTO
{
    public class TuitionDTO
    {
        public int? TuitionFee { get; set; }

        public int? Discount { get; set; }

        public int? Surcharge { get; set; }

        public string? Note { get; set; }

        [Required]
        public int IDClass { get; set; }

        [Required]
        public int IDStudent { get; set; }

        [Required]
        public int IDTuitionType { get; set; }
    }
}
