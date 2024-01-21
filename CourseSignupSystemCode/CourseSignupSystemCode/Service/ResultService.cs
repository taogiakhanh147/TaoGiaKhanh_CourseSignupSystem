using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class ResultService : IResultService
    {
        private readonly CourseSignupSystemContext _context;

        public ResultService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Result>> GetAllResultAsync()
        {
            var results = await _context.Results.ToListAsync();
            if (results.Count == 0)
            {
                throw new NotImplementedException("Result not data");
            }
            return results;
        }

        public async Task<Result> GetResultsByIdAsync(int id)
        {
            var result = await _context.Results.FindAsync(id);
            if (result == null)
            {
                throw new NotImplementedException("Result not exist");
            }
            return result;
        }

        public async Task<Result> AddResultAsync(ResultDTO resultDTO)
        {
            if (resultDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            // Kiểm tra IDStudent
            var student = await _context.Students.FindAsync(resultDTO.IDStudent);
            if(student == null)
            {
                throw new NotImplementedException("Student not found");
            }
            // Kiểm tra IDSubject
            var subject = await _context.SubjectOfStudents
                        .Where(s => s.ID == resultDTO.IDSubject)
                        .Include(s => s.Class)
                        .ThenInclude(c => c.Students)
                        .FirstOrDefaultAsync(st => st.ID == student.ID);
            if(subject == null)
            {
                throw new NotImplementedException("Subject not found");
            }
            // Nếu thành công
            var newResult = new Result
            {
                Score = resultDTO.Score,
                IDSubject = resultDTO.IDSubject,
                IDStudent = resultDTO.IDStudent
            };
            _context.Results.Add(newResult);
            await _context.SaveChangesAsync();
            return newResult;
        }

        public async Task<Result> UpdateResultAsync(int id, ResultDTO resultDTO)
        {
            var existingResult = await _context.Results.FindAsync(id);
            if (existingResult == null)
            {
                throw new NotImplementedException("Result not exist");
            }
            // Kiểm tra IDStudent
            var student = await _context.Students.FindAsync(resultDTO.IDStudent);
            if (student == null)
            {
                throw new NotImplementedException("Student not found");
            }
            // Kiểm tra IDSubject
            var subject = await _context.SubjectOfStudents
                        .Where(s => s.ID == resultDTO.IDSubject)
                        .Include(s => s.Class)
                        .ThenInclude(c => c.Students)
                        .FirstOrDefaultAsync(st => st.ID == student.ID);
            if (subject == null)
            {
                throw new NotImplementedException("Subject not found");
            }
            // Nếu thành công
            existingResult.Score = resultDTO.Score;
            existingResult.IDSubject = resultDTO.IDSubject;
            existingResult.IDStudent = resultDTO.IDStudent;
            _context.Results.Update(existingResult);
            await _context.SaveChangesAsync();
            return existingResult;
        }

        public async Task DeleteResultAsync(int id)
        {
            var existingResult = await _context.Results.SingleOrDefaultAsync(r => r.ID == id);
            if (existingResult == null)
            {
                throw new NotImplementedException("Result not exist");
            }
            _context.Results.Remove(existingResult);
            await _context.SaveChangesAsync();
        }
    }
}
