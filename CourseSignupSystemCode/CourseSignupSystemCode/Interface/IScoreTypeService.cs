using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface IScoreTypeService
    {
        public Task<List<ScoreType>> GetAllScoreTypeAsync();

        public Task<ScoreType> GetScoreTypesByIdAsync(int id);

        public Task<ScoreType> AddScoreTypeAsync(ScoreTypeDTO scoreTypeDTO);

        public Task<ScoreType> UpdateScoreTypeAsync(int id, ScoreTypeDTO scoreTypeDTO);

        public Task DeleteScoreTypeAsync(int id);
    }
}
