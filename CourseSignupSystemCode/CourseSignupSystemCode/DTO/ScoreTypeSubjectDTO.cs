using CourseSignupSystemCode.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CourseSignupSystemCode.DTO
{
    public class ScoreTypeSubjectDTO
    {
        public int? GradingColumn { get; set; }

        public int? RequiredGradeColumns { get; set; }

        [Required]
        public int IDCourse { get; set; }

        [Required]
        public int IDSubject { get; set; }

        [Required]
        public int IDScoreType { get; set; }
    }
}
