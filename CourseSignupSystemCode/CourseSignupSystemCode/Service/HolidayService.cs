using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class HolidayService : IHolidayService
    {
        private readonly CourseSignupSystemContext _context;

        public HolidayService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Holiday>> GetAllHolidayAsync()
        {
            var holidays = await _context.Holidays.ToListAsync();
            if (holidays.Count == 0)
            {
                throw new NotImplementedException("Holiday not data");
            }
            return holidays;
        }

        public async Task<Holiday> GetHolidaysByIdAsync(int id)
        {
            var holiday = await _context.Holidays.FindAsync(id);
            if (holiday == null)
            {
                throw new NotImplementedException("Holiday not exist");
            }
            return holiday;
        }

        public async Task<Holiday> AddHolidayAsync(HolidayDTO holidayDTO)
        {
            if (holidayDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            var newHoliday = new Holiday
            {
                HolidayName = holidayDTO.HolidayName,
                Reason = holidayDTO.Reason,
                StartDay = holidayDTO.StartDay,
                EndDay = holidayDTO.EndDay
            };
            _context.Holidays.Add(newHoliday);
            await _context.SaveChangesAsync();
            return newHoliday;
        }

        public async Task<Holiday> UpdateHolidayAsync(int id, HolidayDTO holidayDTO)
        {
            var existingHoliday = await _context.Holidays.FindAsync(id);
            if (existingHoliday == null)
            {
                throw new NotImplementedException("Holiday not exist");
            }
            existingHoliday.HolidayName = holidayDTO.HolidayName;
            existingHoliday.Reason = holidayDTO.Reason;
            existingHoliday.StartDay = holidayDTO.StartDay;
            existingHoliday.EndDay = holidayDTO.EndDay;
            _context.Holidays.Update(existingHoliday);
            await _context.SaveChangesAsync();
            return existingHoliday;
        }

        public async Task DeleteHolidayAsync(int id)
        {
            var existingHoliday = await _context.Holidays.SingleOrDefaultAsync(h => h.ID == id);
            if (existingHoliday == null)
            {
                throw new NotImplementedException("Holiday not exist");
            }
            _context.Holidays.Remove(existingHoliday);
            await _context.SaveChangesAsync();
        }
    }
}
