using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface ITeachingScheduleService
    {
        public Task<List<TeachingSchedule>> GetAllTeachingScheduleAsync();

        public Task<TeachingSchedule> GetTeachingSchedulesByIdAsync(int id);

        public Task<TeachingSchedule> AddTeachingScheduleAsync(TeachingScheduleDTO teachingScheduleDTO);

        public Task<TeachingSchedule> UpdateTeachingScheduleAsync(int id, TeachingScheduleDTO teachingScheduleDTO);

        public Task DeleteTeachingScheduleAsync(int id);
    }
}
