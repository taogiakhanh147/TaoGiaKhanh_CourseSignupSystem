using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class ScoreTypeSubjectService : IScoreTypeSubjectService
    {
        private readonly CourseSignupSystemContext _context;

        public ScoreTypeSubjectService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<ScoreTypeSubject>> GetAllScoreTypeSubjectAsync()
        {
            var scoreTypeSubjects = await _context.ScoreTypeSubjects.ToListAsync();
            if (scoreTypeSubjects.Count == 0)
            {
                throw new NotImplementedException("ScoreTypeSubject not data");
            }
            return scoreTypeSubjects;
        }

        public async Task<ScoreTypeSubject> GetScoreTypeSubjectsByIdAsync(int id)
        {
            var scoreTypeSubject = await _context.ScoreTypeSubjects.FindAsync(id);
            if (scoreTypeSubject == null)
            {
                throw new NotImplementedException("ScoreTypeSubject not exist");
            }
            return scoreTypeSubject;
        }

        public async Task<ScoreTypeSubject> AddScoreTypeSubjectAsync(ScoreTypeSubjectDTO scoreTypeSubjectDTO)
        {
            if (scoreTypeSubjectDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            // Kiểm tra IDSubject
            var subject = await _context.SubjectOfStudents.FindAsync(scoreTypeSubjectDTO.IDSubject);

            if (subject == null)
            {
                throw new NotImplementedException("Subject not found");
            }
            // Kiểm tra IDCourse
            var course = await _context.Courses
                       .Where(c => c.ID == scoreTypeSubjectDTO.IDCourse)
                       .Include(c => c.Classes)
                       .ThenInclude(cl => cl.SubjectOfStudents)
                       .AnyAsync(s => s.ID == scoreTypeSubjectDTO.IDSubject);
            if (!course)
            {
                throw new NotImplementedException("Course not found");
            }
            // Kiểm tra IDScoreType
            var scoreType = await _context.ScoreTypes.FindAsync(scoreTypeSubjectDTO.IDScoreType);
            if (scoreType == null)
            {
                throw new NotImplementedException("ScoreType not found");
            }

            var newScoreTypeSubject = new ScoreTypeSubject
            {
                GradingColumn = scoreTypeSubjectDTO.GradingColumn,
                RequiredGradeColumns = scoreTypeSubjectDTO.RequiredGradeColumns,
                IDCourse = scoreTypeSubjectDTO.IDCourse,
                IDSubject = scoreTypeSubjectDTO.IDSubject,
                IDScoreType = scoreTypeSubjectDTO.IDScoreType
            };
            _context.ScoreTypeSubjects.Add(newScoreTypeSubject);
            await _context.SaveChangesAsync();
            return newScoreTypeSubject;
        }

        public async Task<ScoreTypeSubject> UpdateScoreTypeSubjectAsync(int id, ScoreTypeSubjectDTO scoreTypeSubjectDTO)
        {
            var existingScoreTypeSubject = await _context.ScoreTypeSubjects.FindAsync(id);
            if (existingScoreTypeSubject == null)
            {
                throw new NotImplementedException("ScoreTypeSubject not exist");
            }
            // Kiểm tra IDSubject
            var subject = await _context.SubjectOfStudents.FindAsync(scoreTypeSubjectDTO.IDSubject);

            if (subject == null)
            {
                throw new NotImplementedException("Subject not found");
            }
            // Kiểm tra IDCourse
            var course = await _context.Courses
                       .Where(c => c.ID == scoreTypeSubjectDTO.IDCourse)
                       .SelectMany(c => c.Classes)
                       .SelectMany(cl => cl.SubjectOfStudents)
                       .AnyAsync(s => s.ID == scoreTypeSubjectDTO.IDSubject);
            if (!course)
            {
                throw new NotImplementedException("Course not found");
            }
            // Kiểm tra IDScoreType
            var scoreType = await _context.ScoreTypes.FindAsync(scoreTypeSubjectDTO.IDScoreType);
            if (scoreType == null)
            {
                throw new NotImplementedException("ScoreType not found");
            }
            existingScoreTypeSubject.GradingColumn = scoreTypeSubjectDTO.GradingColumn;
            existingScoreTypeSubject.RequiredGradeColumns = scoreTypeSubjectDTO.RequiredGradeColumns;
            existingScoreTypeSubject.IDCourse = scoreTypeSubjectDTO.IDCourse;
            existingScoreTypeSubject.IDSubject = scoreTypeSubjectDTO.IDSubject;
            existingScoreTypeSubject.IDScoreType = scoreTypeSubjectDTO.IDScoreType;
            _context.ScoreTypeSubjects.Update(existingScoreTypeSubject);
            await _context.SaveChangesAsync();
            return existingScoreTypeSubject;
        }

        public async Task DeleteScoreTypeSubjectAsync(int id)
        {
            var existingScoreTypeSubject = await _context.ScoreTypeSubjects.SingleOrDefaultAsync(s => s.ID == id);
            if (existingScoreTypeSubject == null)
            {
                throw new NotImplementedException("ScoreTypeSubject not exist");
            }
            _context.ScoreTypeSubjects.Remove(existingScoreTypeSubject);
            await _context.SaveChangesAsync();
        }
    }
}
