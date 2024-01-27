using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class RevenueService : IRevenueService
    {
        private readonly CourseSignupSystemContext _context;
        public RevenueService(CourseSignupSystemContext context)
        {
            _context = context;
        }
        
        public async Task<List<GetAllInfoStudentHavePaidDTO>> GetAllInfoStudentHavePaidAsync()
        {
            var student = await _context.Students
                          .Where(s => _context.Tuitions.Any(t => t.IDStudent == s.ID))
                          .Select(s => new GetAllInfoStudentHavePaidDTO
                          {
                              IdStudent = s.ID,
                              Image = s.Image,
                              FullName = s.LastName + " " + s.MiddleAndFirstName,
                              FullNameOfParent = s.FullNameOfParent,
                              Address = s.Address,
                              Date = s.Date,
                              Phone = s.Phone,
                              Email = s.Email,
                              ClassName = s.Class.ClassName
                          })
                          .ToListAsync();
            return student.ToList();
        }

        public async Task<List<GetAllInfoTeacherSalaryDTO>> GetAllInfoTeacherSalaryAsync()
        {
            var teacher = await _context.Teachers
                        .Where(t => _context.Salaries.Any(s => s.IDTeacher == t.ID))
                        .Select(t => new GetAllInfoTeacherSalaryDTO
                        {
                            IdTeacher = t.ID,
                            FullName = t.LastName + " " + t.MiddleAndFirstName,
                            Email = t.Email,
                            Phone = t.Phone,
                            SalaryNet = _context.Salaries
                                      .Where(s => s.IDTeacher == t.ID)
                                      .Select(s => (s.SalaryNet ?? 0))
                                      .FirstOrDefault()
                        })
                        .ToListAsync();
            return teacher.ToList();
        }

        public async Task<GetRevenueStatisticsDTO> GetRevenueStatisticsAsync()
        {
            var totalRevenueTuitionOfStudent = _context.Tuitions.Sum(t => t.TotalTuition) ?? 0;
            var totalRevenueSalaryTeacher = _context.Salaries.Sum(s => s.SalaryNet) ?? 0;

            var revenue = new GetRevenueStatisticsDTO
            {
                TotalRevenueTuitionOfStudent = totalRevenueTuitionOfStudent,
                TotalRevenueSalaryTeacher = totalRevenueSalaryTeacher,
                TotalRevenueReceived = totalRevenueTuitionOfStudent - totalRevenueSalaryTeacher
            };

            return revenue;
        }
    }
}
