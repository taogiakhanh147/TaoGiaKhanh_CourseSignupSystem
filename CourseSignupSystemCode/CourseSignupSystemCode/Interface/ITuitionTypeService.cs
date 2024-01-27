using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface ITuitionTypeService
    {
        public Task<List<TuitionType>> GetAllTuitionTypeAsync();

        public Task<TuitionType> GetTuitionTypesByIdAsync(int id);

        public Task<TuitionType> AddTuitionTypeAsync(TuitionTypeDTO tuitionTypeDTO);

        public Task<TuitionType> UpdateTuitionTypeAsync(int id, TuitionTypeDTO tuitionTypeDTO);

        public Task DeleteTuitionTypeAsync(int id);
    }
}
