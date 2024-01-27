using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystemCode.DTO
{
    public class ResultDTO
    {
        public float? Score { get; set; }

        [Required]
        public int IDSubject { get; set; }

        [Required]
        public int IDScoreType { get; set; }

        [Required]
        public int IDStudent { get; set; }
    }
}
