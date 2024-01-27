using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface IHolidayService
    {
        public Task<List<Holiday>> GetAllHolidayAsync();

        public Task<Holiday> GetHolidaysByIdAsync(int id);

        public Task<Holiday> AddHolidayAsync(HolidayDTO holidayDTO);

        public Task<Holiday> UpdateHolidayAsync(int id, HolidayDTO holidayDTO);

        public Task DeleteHolidayAsync(int id);
    }
}
