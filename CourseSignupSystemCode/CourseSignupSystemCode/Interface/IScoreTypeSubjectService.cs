using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface IScoreTypeSubjectService
    {
        public Task<List<ScoreTypeSubject>> GetAllScoreTypeSubjectAsync();

        public Task<ScoreTypeSubject> GetScoreTypeSubjectsByIdAsync(int id);

        public Task<List<GetAllSubjectsDTO>> GetAllSubjectsAsync();

        public Task<ScoreTypeSubject> AddScoreTypeSubjectAsync(ScoreTypeSubjectDTO scoreTypeSubjectDTO);

        public Task<ScoreTypeSubject> UpdateScoreTypeSubjectAsync(int id, ScoreTypeSubjectDTO scoreTypeSubjectDTO);

        public Task DeleteScoreTypeSubjectAsync(int id);
    }
}
