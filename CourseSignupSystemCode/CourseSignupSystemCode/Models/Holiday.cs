using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystemCode.Models
{
    [Table("Holiday")]
    public class Holiday
    {
        [Key]
        public int ID { get; set; }

        public string? HolidayName { get; set; }

        public string? Reason { get; set; }

        public DateTime? StartDay { get; set; }

        public DateTime? EndDay { get; set; }

    }
}
