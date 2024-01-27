using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class SalaryService : ISalaryService
    {
        private readonly CourseSignupSystemContext _context;

        public SalaryService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Salary>> GetAllSalaryAsync()
        {
            var salaries = await _context.Salaries.ToListAsync();
            if (salaries.Count == 0)
            {
                throw new NotImplementedException("Salary not data");
            }
            return salaries;
        }

        public async Task<Salary> GetSalarysByIdAsync(int id)
        {
            var salary = await _context.Salaries.FindAsync(id);
            if (salary == null)
            {
                throw new NotImplementedException("Salary not exist");
            }
            return salary;
        }

        public async Task<Salary> AddSalaryAsync(SalaryDTO salaryDTO)
        {
            if (salaryDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            // Kiểm tra IDClass
            var Class = await _context.Classes.FindAsync(salaryDTO.IDClass);
            if(Class == null)
            {
                throw new NotImplementedException("Class not found");
            }
            // Kiểm tra IDTeacher
            var teacher = await _context.Teachers
                        .Where(t => t.ID == salaryDTO.IDTeacher)
                        .Select(t => t.SubjectOfTeacher)
                        .Select(s => s.Class)
                        .FirstOrDefaultAsync(c => c.ID == Class.ID);
            if(teacher == null)
            {
                throw new NotImplementedException("Teacher not found");
            }
            // Tính toán SalaryNet
            int fee = Class.Fee ?? 0;
            int numberOfStudents = Class.NumberOfStudent ?? 0;
            int salaryPercent = salaryDTO.SalaryPercent ?? 0;
            int allowance = salaryDTO.Allowance ?? 0;
            int salaryNet = (fee * numberOfStudents * salaryPercent / 100) + allowance;
            // Nếu thành công
            var newSalary = new Salary
            {
                SalaryPercent = salaryDTO.SalaryPercent,
                Allowance = salaryDTO.Allowance,
                Note = salaryDTO.Note,
                SalaryNet = salaryNet,
                IDTeacher = salaryDTO.IDTeacher,
                IDClass = salaryDTO.IDClass
            };
            _context.Salaries.Add(newSalary);
            await _context.SaveChangesAsync();
            return newSalary;
        }

        public async Task<Salary> UpdateSalaryAsync(int id, SalaryDTO salaryDTO)
        {
            var existingSalary = await _context.Salaries.FindAsync(id);
            if (existingSalary == null)
            {
                throw new NotImplementedException("Salary not exist");
            }
            // Kiểm tra IDClass
            var Class = await _context.Classes.FindAsync(salaryDTO.IDClass);
            if (Class == null)
            {
                throw new NotImplementedException("Class not found");
            }
            // Kiểm tra IDTeacher
            var teacher = await _context.Teachers
                        .Where(t => t.ID == salaryDTO.IDTeacher)
                        .Select(t => t.SubjectOfTeacher)
                        .Select(s => s.Class)
                        .FirstOrDefaultAsync(c => c.ID == Class.ID);
            if (teacher == null)
            {
                throw new NotImplementedException("Teacher not found");
            }
            // Tính toán SalaryNet
            int fee = Class.Fee ?? 0;
            int numberOfStudents = Class.NumberOfStudent ?? 0;
            int salaryPercent = salaryDTO.SalaryPercent ?? 0;
            int allowance = salaryDTO.Allowance ?? 0;
            int salaryNet = (fee * numberOfStudents * salaryPercent / 100) + allowance;
            // Nếu thành công
            existingSalary.SalaryPercent = salaryDTO.SalaryPercent;
            existingSalary.Allowance = salaryDTO.Allowance;
            existingSalary.Note = salaryDTO.Note;
            existingSalary.SalaryNet = salaryNet;
            existingSalary.IDTeacher = salaryDTO.IDTeacher;
            existingSalary.IDClass = salaryDTO.IDClass;
            _context.Salaries.Update(existingSalary);
            await _context.SaveChangesAsync();
            return existingSalary;
        }

        public async Task DeleteSalaryAsync(int id)
        {
            var existingSalary = await _context.Salaries.SingleOrDefaultAsync(s => s.ID == id);
            if (existingSalary == null)
            {
                throw new NotImplementedException("Salary not exist");
            }
            _context.Salaries.Remove(existingSalary);
            await _context.SaveChangesAsync();
        }
    }
}
