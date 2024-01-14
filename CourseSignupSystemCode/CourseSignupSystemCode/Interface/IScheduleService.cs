using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface IScheduleService
    {
        public Task<List<Schedule>> GetAllScheduleAsync();

        public Task<Schedule> GetSchedulesByIdAsync(int id);

        public Task<Schedule> AddScheduleAsync(ScheduleDTO scheduleDTO);

        public Task<Schedule> UpdateScheduleAsync(int id, ScheduleDTO scheduleDTO);

        public Task DeleteScheduleAsync(int id);
    }
}
