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
    public class StudentService : IStudentService
    {
        private readonly CourseSignupSystemContext _context;
        public StudentService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            var students = await _context.Students.ToListAsync();
            if (students.Count == 0)
            {
                throw new NotImplementedException("Student not data");
            }
            return students;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                throw new NotImplementedException("Student not exist");
            }
            return student;
        }

        public async Task<Student> AddStudentAsync(StudentDTO studentDTO)
        {
            if (studentDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            var newStudent = new Student
            {
                LastName = studentDTO.LastName,
                MiddleAndFirstName = studentDTO.MiddleAndFirstName,
                Date = studentDTO.Date,
                Sex = studentDTO.Sex,
                Email = studentDTO.Email,
                Phone = studentDTO.Phone,
                Address = studentDTO.Address,
                FullNameOfParent = studentDTO.FullNameOfParent,
                Password = studentDTO.Password,
                IDClass = studentDTO.IDClass,
                IDRole = studentDTO.IDRole
            };
            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();
            return newStudent;
        }

        public async Task<Student> UploadImageStudentAsync(int id, IFormFile file)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.ID == id);
            if (existingStudent == null)
            {
                throw new NotImplementedException("Student not exist");
            }
            if (file != null)
            {
                existingStudent.Image = await SaveFile(file);
                await _context.SaveChangesAsync();
            }
            return existingStudent;
        }

        public async Task<Student> UpdateStudentAsync(int id, StudentDTO studentDTO)
        {
            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent == null)
            {
                throw new NotImplementedException("Student not exist");
            }
            existingStudent.LastName = studentDTO.LastName;
            existingStudent.MiddleAndFirstName = studentDTO.MiddleAndFirstName;
            existingStudent.Date = studentDTO.Date;
            existingStudent.Sex = studentDTO.Sex;
            existingStudent.Email = studentDTO.Email;
            existingStudent.Phone = studentDTO.Phone;
            existingStudent.Address = studentDTO.Address;
            existingStudent.FullNameOfParent = studentDTO.FullNameOfParent;
            existingStudent.Password = studentDTO.Password;
            existingStudent.IDClass = studentDTO.IDClass;
            existingStudent.IDRole = studentDTO.IDRole;
            _context.Students.Update(existingStudent);
            await _context.SaveChangesAsync();
            return existingStudent;
        }

        public async Task<Student> UpdateImageStudentAsync(int id, IFormFile file)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.ID == id);
            if (existingStudent == null)
            {
                throw new NotImplementedException("Student not exist");
            }
            existingStudent.Image = await SaveFile(file);
            await _context.SaveChangesAsync();
            return existingStudent;
        }

        public async Task DeleteStudentAsync(int id)
        {
            var existingStudent = await _context.Students.SingleOrDefaultAsync(s => s.ID == id);
            if (existingStudent == null)
            {
                throw new NotImplementedException("Student not exist");
            }
            _context.Students.Remove(existingStudent);
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
