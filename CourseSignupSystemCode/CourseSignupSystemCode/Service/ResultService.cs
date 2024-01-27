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

        public async Task<List<GetResultByStudentDTO>> GetResultByStudentAsync(string email, int idCourse)
        {
            // Tìm tất cả các Student có cùng Email
            var students = await _context.Students
                         .Where(s => s.Email == email)
                         .Include(s => s.Class)
                         .ThenInclude(c => c.SubjectOfStudents)
                         .ThenInclude(subject => subject.ScoreTypeSubjects)
                         .ThenInclude(score => score.ScoreType)
                         .ToListAsync();

            if (students.Count == 0)
            {
                // Nếu không tìm thấy Student, trả về danh sách rỗng
                throw new NotImplementedException("Student not found");
            }

            // Lấy danh sách ID của các Student
            var studentIds = students.Select(s => s.ID).ToList();

            // Tìm kết quả (Result) của Student theo IDStudent và IDCourse
            var results = _context.Results
                .Where(r => studentIds.Contains(r.IDStudent) && r.Student.Class.IDCourse == idCourse)
                .Select(r => new GetResultByStudentDTO
                {
                    SubjectName = _context.SubjectOfStudents
                                .Where(subject => subject.ID == r.IDSubject)
                                .Select(subject => subject.SubjectName)
                                .FirstOrDefault(),
                    ScoreTypeName = _context.ScoreTypeSubjects
                                .Where(scoreType => scoreType.IDSubject == r.IDSubject)
                                .Select(scoreType => scoreType.ScoreType.ScoreTypeName)
                                .FirstOrDefault(),
                    Score = r.Score
                })
                .ToList();

            return results;
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
                        .Select(s => s.Class)
                        .SelectMany(c => c.Students)
                        .FirstOrDefaultAsync(st => st.ID == student.ID);
            if(subject == null)
            {
                throw new NotImplementedException("Subject not found");
            }
            // Kiểm tra IDScoreType
            var scoreType = await _context.ScoreTypes
                          .Where(s => s.ID == resultDTO.IDScoreType)
                          .SelectMany(s => s.ScoreTypeSubjects)
                          .Select(st => st.SubjectOfStudent)
                          .FirstOrDefaultAsync(sub => sub.ID == resultDTO.IDSubject);
            if(scoreType == null)
            {
                throw new NotImplementedException("ScoreType not found");
            }
            // Nếu thành công
            var newResult = new Result
            {
                Score = resultDTO.Score,
                IDSubject = resultDTO.IDSubject,
                IDScoreType = resultDTO.IDScoreType,
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
                        .Select(s => s.Class)
                        .SelectMany(c => c.Students)
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
