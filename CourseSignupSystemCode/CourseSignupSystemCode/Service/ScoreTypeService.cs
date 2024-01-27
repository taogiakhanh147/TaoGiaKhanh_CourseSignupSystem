using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class ScoreTypeService : IScoreTypeService
    {
        private readonly CourseSignupSystemContext _context;

        public ScoreTypeService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<ScoreType>> GetAllScoreTypeAsync()
        {
            var scoreTypes = await _context.ScoreTypes.ToListAsync();
            if (scoreTypes.Count == 0)
            {
                throw new NotImplementedException("ScoreType not data");
            }
            return scoreTypes;
        }

        public async Task<ScoreType> GetScoreTypesByIdAsync(int id)
        {
            var scoreType = await _context.ScoreTypes.FindAsync(id);
            if (scoreType == null)
            {
                throw new NotImplementedException("ScoreType not exist");
            }
            return scoreType;
        }

        public async Task<ScoreType> AddScoreTypeAsync(ScoreTypeDTO scoreTypeDTO)
        {
            if (scoreTypeDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            var newScoreType = new ScoreType
            {
                ScoreTypeName = scoreTypeDTO.ScoreTypeName,
                ScoreScale = scoreTypeDTO.ScoreScale
            };
            _context.ScoreTypes.Add(newScoreType);
            await _context.SaveChangesAsync();
            return newScoreType;
        }

        public async Task<ScoreType> UpdateScoreTypeAsync(int id, ScoreTypeDTO scoreTypeDTO)
        {
            var existingScoreType = await _context.ScoreTypes.FindAsync(id);
            if (existingScoreType == null)
            {
                throw new NotImplementedException("ScoreType not exist");
            }
            existingScoreType.ScoreTypeName = scoreTypeDTO.ScoreTypeName;
            existingScoreType.ScoreScale = scoreTypeDTO.ScoreScale;
            _context.ScoreTypes.Update(existingScoreType);
            await _context.SaveChangesAsync();
            return existingScoreType;
        }

        public async Task DeleteScoreTypeAsync(int id)
        {
            var existingScoreType = await _context.ScoreTypes.SingleOrDefaultAsync(s => s.ID == id);
            if (existingScoreType == null)
            {
                throw new NotImplementedException("ScoreType not exist");
            }
            _context.ScoreTypes.Remove(existingScoreType);
            await _context.SaveChangesAsync();
        }
    }
}
