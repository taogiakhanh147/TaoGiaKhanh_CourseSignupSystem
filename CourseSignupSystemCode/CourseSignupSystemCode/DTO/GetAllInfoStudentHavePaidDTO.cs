namespace CourseSignupSystemCode.DTO
{
    public class GetAllInfoStudentHavePaidDTO
    {
        public int IdStudent { get; set; }

        public string? Image { get; set; }

        public string? FullName { get; set; }

        public string? FullNameOfParent { get; set; }

        public string? Address { get; set; }

        public DateTime? Date { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? ClassName { get; set; }
    }
}
