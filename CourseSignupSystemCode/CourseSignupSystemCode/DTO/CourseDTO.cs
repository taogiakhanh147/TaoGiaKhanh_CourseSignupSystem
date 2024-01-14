using System.ComponentModel.DataAnnotations;

namespace CourseSignupSystemCode.DTO
{
    public class CourseDTO
    {
        public string? CourseNO { get; set; }

        public string? CourseName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CourseStartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CourseEndDate { get; set; }
    }
}
