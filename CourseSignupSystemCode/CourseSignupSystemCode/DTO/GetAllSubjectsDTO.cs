namespace CourseSignupSystemCode.DTO
{
    public class GetAllSubjectsDTO
    {
        public int? GradingColumn { get; set; }

        public int? RequiredGradeColumns { get; set; }

        public string? CourseName { get; set; }

        public string? SubjectName {  get; set; }
        
        public string? ScoreTypeName { get; set; }
    }
}
