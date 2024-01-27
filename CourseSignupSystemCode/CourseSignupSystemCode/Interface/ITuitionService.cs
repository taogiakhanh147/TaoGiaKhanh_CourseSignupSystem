using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface ITuitionService
    {
        public Task<List<Tuition>> GetAllTuitionAsync();

        public Task<Tuition> GetTuitionsByIdAsync(int id);

        public Task<Tuition> AddTuitionAsync(TuitionDTO tuitionDTO);

        public Task<Tuition> UpdateTuitionAsync(int id, TuitionDTO tuitionDTO);

        public Task DeleteTuitionAsync(int id);
    }
}
