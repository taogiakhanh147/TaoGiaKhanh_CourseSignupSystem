using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Numerics;

namespace CourseSignupSystemCode.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly CourseSignupSystemContext _context;
        public TeacherService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> GetAllTeacherAsync()
        {
            var teachers = await _context.Teachers.ToListAsync();
            if (teachers.Count == 0)
            {
                throw new NotImplementedException("Teacher not data");
            }
            return teachers;
        }

        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                throw new NotImplementedException("Teacher not exist");
            }
            return teacher;
        }

        public async Task<Teacher> AddTeacherAsync(TeacherDTO teacherDTO)
        {
            if (teacherDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            var newTeacher = new Teacher
            {
                TaxCode = teacherDTO.TaxCode,
                LastName = teacherDTO.LastName,
                MiddleAndFirstName = teacherDTO.MiddleAndFirstName,
                Date = teacherDTO.Date,
                Sex = teacherDTO.Sex,
                Email = teacherDTO.Email,
                Phone = teacherDTO.Phone,
                Address = teacherDTO.Address,
                MainSubject = teacherDTO.MainSubject,
                PartTimeSubject = teacherDTO.PartTimeSubject,
                Password = teacherDTO.Password,
                IDRole = teacherDTO.IDRole
            };
            _context.Teachers.Add(newTeacher);
            await _context.SaveChangesAsync();
            return newTeacher;
        }

        public async Task<Teacher> UploadImageTeacherAsync(int id, IFormFile file)
        {
            var existingTeacher = await _context.Teachers.FirstOrDefaultAsync(t => t.ID == id);
            if (existingTeacher == null)
            {
                throw new NotImplementedException("Teacher not exist");
            }
            if (file != null)
            {
                existingTeacher.Image = await SaveFile(file);
                await _context.SaveChangesAsync();
            }
            return existingTeacher;
        }

        public async Task<Teacher> UpdateTeacherAsync(int id, TeacherDTO teacherDTO)
        {
            var existingTeacher = await _context.Teachers.FindAsync(id);
            if (existingTeacher == null)
            {
                throw new NotImplementedException("Teacher not exist");
            }
            existingTeacher.TaxCode = teacherDTO.TaxCode;
            existingTeacher.LastName = teacherDTO.LastName;
            existingTeacher.MiddleAndFirstName = teacherDTO.MiddleAndFirstName;
            existingTeacher.Date = teacherDTO.Date;
            existingTeacher.Sex = teacherDTO.Sex;
            existingTeacher.Email = teacherDTO.Email;
            existingTeacher.Phone = teacherDTO.Phone;
            existingTeacher.Address = teacherDTO.Address;
            existingTeacher.MainSubject = teacherDTO.MainSubject;
            existingTeacher.PartTimeSubject = teacherDTO.PartTimeSubject;
            existingTeacher.Password = teacherDTO.Password;
            existingTeacher.IDRole = teacherDTO.IDRole;
            _context.Teachers.Update(existingTeacher);
            await _context.SaveChangesAsync();
            return existingTeacher;
        }

        public async Task<Teacher> UpdateImageTeacherAsync(int id, IFormFile file)
        {
            var existingTeacher = await _context.Teachers.FirstOrDefaultAsync(t => t.ID == id);
            if (existingTeacher == null)
            {
                throw new NotImplementedException("Teacher not exist");
            }
            existingTeacher.Image = await SaveFile(file);
            await _context.SaveChangesAsync();
            return existingTeacher;
        }

        public async Task DeleteTeacherAsync(int id)
        {
            var existingTeacher = await _context.Teachers.SingleOrDefaultAsync(u => u.ID == id);
            if (existingTeacher == null)
            {
                throw new NotImplementedException("Teacher not exist");
            }
            _context.Teachers.Remove(existingTeacher);
            await _context.SaveChangesAsync();

        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var filePath = Path.Combine("D:\\Alta SoftWare\\CourseSignupSystem\\CourseSignupSystemCode\\CourseSignupSystemCode\\Upload", file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;
        }
    }
}
