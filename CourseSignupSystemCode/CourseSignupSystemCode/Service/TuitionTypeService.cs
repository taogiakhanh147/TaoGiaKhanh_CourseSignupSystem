using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class TuitionTypeService : ITuitionTypeService
    {
        private readonly CourseSignupSystemContext _context;

        public TuitionTypeService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<TuitionType>> GetAllTuitionTypeAsync()
        {
            var tuitionTypes = await _context.TuitionTypes.ToListAsync();
            if (tuitionTypes.Count == 0)
            {
                throw new NotImplementedException("TuitionType not data");
            }
            return tuitionTypes;
        }

        public async Task<TuitionType> GetTuitionTypesByIdAsync(int id)
        {
            var tuitionType = await _context.TuitionTypes.FindAsync(id);
            if (tuitionType == null)
            {
                throw new NotImplementedException("TuitionType not exist");
            }
            return tuitionType;
        }

        public async Task<TuitionType> AddTuitionTypeAsync(TuitionTypeDTO tuitionTypeDTO)
        {
            if (tuitionTypeDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            var newTuitionType = new TuitionType
            {
                TuitionTypeName = tuitionTypeDTO.TuitionTypeName
            };
            _context.TuitionTypes.Add(newTuitionType);
            await _context.SaveChangesAsync();
            return newTuitionType;
        }

        public async Task<TuitionType> UpdateTuitionTypeAsync(int id, TuitionTypeDTO tuitionTypeDTO)
        {
            var existingTuitionType = await _context.TuitionTypes.FindAsync(id);
            if (existingTuitionType == null)
            {
                throw new NotImplementedException("TuitionType not exist");
            }
            existingTuitionType.TuitionTypeName = tuitionTypeDTO.TuitionTypeName;
            _context.TuitionTypes.Update(existingTuitionType);
            await _context.SaveChangesAsync();
            return existingTuitionType;
        }

        public async Task DeleteTuitionTypeAsync(int id)
        {
            var existingTuitionType = await _context.TuitionTypes.SingleOrDefaultAsync(t => t.ID == id);
            if (existingTuitionType == null)
            {
                throw new NotImplementedException("TuitionType not exist");
            }
            _context.TuitionTypes.Remove(existingTuitionType);
            await _context.SaveChangesAsync();
        }
    }
}
