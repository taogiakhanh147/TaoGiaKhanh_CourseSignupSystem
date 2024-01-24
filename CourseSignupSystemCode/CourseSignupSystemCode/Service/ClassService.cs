using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class ClassService : IClassService
    {
        private readonly CourseSignupSystemContext _context;
        public ClassService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Class>> GetAllClassAsync()
        {
            var classes = await _context.Classes.ToListAsync();
            if (classes.Count == 0)
            {
                throw new NotImplementedException("Class not data");
            }
            return classes;
        }

        public async Task<Class> GetClassByIdAsync(int id)
        {
            var Class = await _context.Classes.FindAsync(id);
            if (Class == null)
            {
                throw new NotImplementedException("Class not exist");
            }
            return Class;
        }


        public async Task<List<GetAllStudentInClassDTO>> GetAllStudentInClassAsync(int id)
        {
            var studentsInClass = await _context.Students
                .Where(s => s.IDClass == id)
                .ToListAsync();

            var tuitionIds = await _context.Tuitions
                .Where(t => t.IDClass == id)
                .Select(t => t.IDStudent)
                .ToListAsync();

            var result = studentsInClass.Select(student => new GetAllStudentInClassDTO
            {
                FullName = $"{student.LastName} {student.MiddleAndFirstName}",
                Email = student.Email,
                Phone = student.Phone,
                Status = tuitionIds.Contains(student.ID) ? "Đã đóng học phí" : "Chưa đóng học phí"
            }).ToList();

            return result;
        }

        public async Task<Class> AddClassAsync(ClassDTO classDTO)
        {
            if (classDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            var newClass = new Class
            {
                ClassNO = classDTO.ClassNO,
                ClassName = classDTO.ClassName,
                NumberOfStudent = classDTO.NumberOfStudent,
                Fee = classDTO.Fee,
                Description = classDTO.Description,
                IDCourse= classDTO.IDCourse,
                IDFaculty = classDTO.IDFaculty
            };
            _context.Classes.Add(newClass);
            await _context.SaveChangesAsync();
            return newClass;
        }

        public async Task<Class> UploadImageClassAsync(int id, IFormFile file)
        {
            var existingClass = await _context.Classes.FirstOrDefaultAsync(c => c.ID == id);
            if (existingClass == null)
            {
                throw new NotImplementedException("Class not exist");
            }
            if (file != null)
            {
                existingClass.Image = await SaveFile(file);
                await _context.SaveChangesAsync();
            }
            return existingClass;
        }

        public async Task<Class> UpdateClassAsync(int id, ClassDTO classDTO)
        {
            var existingClass = await _context.Classes.FindAsync(id);
            if (existingClass == null)
            {
                throw new NotImplementedException("Class not exist");
            }
            existingClass.ClassNO = classDTO.ClassNO;
            existingClass.ClassName = classDTO.ClassName;
            existingClass.NumberOfStudent = classDTO.NumberOfStudent;
            existingClass.Fee = classDTO.Fee;
            existingClass.Description = classDTO.Description;
            existingClass.IDCourse = classDTO.IDCourse;
            existingClass.IDFaculty = classDTO.IDFaculty;
            _context.Classes.Update(existingClass);
            await _context.SaveChangesAsync();
            return existingClass;
        }

        public async Task<Class> UpdateImageClassAsync(int id, IFormFile file)
        {
            var existingClass = await _context.Classes.FirstOrDefaultAsync(c => c.ID == id);
            if (existingClass == null)
            {
                throw new NotImplementedException("Class not exist");
            }
            existingClass.Image = await SaveFile(file);
            await _context.SaveChangesAsync();
            return existingClass;
        }

        public async Task DeleteClassAsync(int id)
        {
            var existingClass = await _context.Classes.SingleOrDefaultAsync(c => c.ID == id);
            if (existingClass == null)
            {
                throw new NotImplementedException("Class not exist");
            }
            _context.Classes.Remove(existingClass);
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
