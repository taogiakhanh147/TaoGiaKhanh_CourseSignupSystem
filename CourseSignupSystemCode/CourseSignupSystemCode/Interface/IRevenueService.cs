using CourseSignupSystemCode.DTO;

namespace CourseSignupSystemCode.Interface
{
    public interface IRevenueService
    {
        public Task<List<GetAllInfoStudentHavePaidDTO>> GetAllInfoStudentHavePaidAsync();

        public Task<List<GetAllInfoTeacherSalaryDTO>> GetAllInfoTeacherSalaryAsync();

        public Task<GetRevenueStatisticsDTO> GetRevenueStatisticsAsync();
    }
}
