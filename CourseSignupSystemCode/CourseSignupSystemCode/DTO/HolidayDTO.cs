using System.ComponentModel.DataAnnotations;

namespace CourseSignupSystemCode.DTO
{
    public class HolidayDTO
    {
        public string? HolidayName { get; set; }

        public string? Reason { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDay { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDay { get; set; }
    }
}
