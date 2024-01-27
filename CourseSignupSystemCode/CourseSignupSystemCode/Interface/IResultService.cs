using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface IResultService
    {
        public Task<List<Result>> GetAllResultAsync();

        public Task<Result> GetResultsByIdAsync(int id);

        public Task<List<GetResultByStudentDTO>> GetResultByStudentAsync(string email, int idCourse);

        public Task<Result> AddResultAsync(ResultDTO resultDTO);

        public Task<Result> UpdateResultAsync(int id, ResultDTO resultDTO);

        public Task DeleteResultAsync(int id);
    }
}
