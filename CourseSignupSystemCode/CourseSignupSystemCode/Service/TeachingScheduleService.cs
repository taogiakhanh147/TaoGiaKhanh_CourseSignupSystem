using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace CourseSignupSystemCode.Service
{
    public class TeachingScheduleService : ITeachingScheduleService
    {
        private readonly CourseSignupSystemContext _context;

        public TeachingScheduleService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<TeachingSchedule>> GetAllTeachingScheduleAsync()
        {
            var teachingSchedules = await _context.TeachingSchedules.ToListAsync();
            if (teachingSchedules.Count == 0)
            {
                throw new NotImplementedException("TeachingSchedule not data");
            }
            return teachingSchedules;
        }

        public async Task<TeachingSchedule> GetTeachingSchedulesByIdAsync(int id)
        {
            var teachingSchedule = await _context.TeachingSchedules.FindAsync(id);
            if (teachingSchedule == null)
            {
                throw new NotImplementedException("TeachingSchedule not exist");
            }
            return teachingSchedule;
        }

        public async Task<List<GetScheduleByEmailDTO>> GetScheduleByEmailAsync(string email, int idCourse)
        {
            if (string.IsNullOrEmpty(email) || idCourse==0)
            {
                throw new ArgumentException("User email or IDCourse cannot be null or empty");
            }

            // Lấy IDStudent của người dùng có email được nhập
            var userTeacherIds = await _context.Teachers
                .Where(s => s.Email == email)
                .Select(s => s.ID)
                .ToListAsync();
            if (userTeacherIds.Count == 0)
            {
                throw new NotImplementedException("Email is invalid");
            }

            // Lấy danh sách các lịch học của người dùng
            var userSchedules = await _context.TeachingSchedules
                .Where(ts => userTeacherIds.Contains(ts.IDTeacher) && ts.Teacher.SubjectOfTeacher.Class.Course.ID == idCourse)
                .Include(ts => ts.Teacher)
                .ThenInclude(t => t.SubjectOfTeacher)
                .ThenInclude(s => s.Class)
                .ThenInclude(c => c.Course)
                .ToListAsync();
            if (userSchedules.Count == 0)
            {
                throw new NotImplementedException("Teacher is not schedule");
            }

            // Chuyển đổi danh sách lịch học sang định dạng DTO
            var getScheduleByEmailDTOs = userSchedules.Select(ts => new GetScheduleByEmailDTO
            {
                ClassRoom = ts.ClassRoom,
                StudyTime = ts.TeachTime,
                StudyDay = ts.TeachDay,
                Stage = ts.Stage,
                SubjectName = ts.Teacher.SubjectOfTeacher.SubjectName // Vì Teacher gọi SubjectOfTeacher là gọi đến khóa ngoại trong Teacher nên không thể dùng LINQ
            }).ToList();

            return getScheduleByEmailDTOs;
        }


        public async Task<TeachingSchedule> AddTeachingScheduleAsync(TeachingScheduleDTO teachingScheduleDTO)
        {
            if (teachingScheduleDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }

            var teacher = await _context.Teachers.FindAsync(teachingScheduleDTO.IDTeacher);
            // Kiểm tra giảng viên có tồn tại không
            if (teacher == null)
            {
                throw new Exception("Teacher not found");
            }
            // Kiểm tra môn học giảng viên đó phụ trách có hợp lệ không
            if (teacher.IDSubject != teachingScheduleDTO.IDSubject)
            {
                throw new Exception("Subject not found");
            }

            // Kiểm tra xem lớp có chứa môn học mà giảng viên phụ trách không
            var Class = await _context.Classes
                .Where(c => c.ID == teachingScheduleDTO.IDClass)
                .SelectMany(c => c.SubjectOfTeachers)
                .AnyAsync(s => s.ID == teachingScheduleDTO.IDSubject);

            if (!Class)
            {
                throw new Exception("Class not found");
            }

            var newTeachingSchedule = new TeachingSchedule
            {
                ClassRoom = teachingScheduleDTO.ClassRoom,
                TeachTime = teachingScheduleDTO.TeachTime,
                TeachDay = teachingScheduleDTO.TeachDay,
                Stage = teachingScheduleDTO.Stage,
                IDClass = teachingScheduleDTO.IDClass,
                IDSubject = teachingScheduleDTO.IDSubject,
                IDTeacher = teachingScheduleDTO.IDTeacher
            };

            _context.TeachingSchedules.Add(newTeachingSchedule);
            await _context.SaveChangesAsync();

            return newTeachingSchedule;
        }

        public async Task<TeachingSchedule> UpdateTeachingScheduleAsync(int id, TeachingScheduleDTO teachingScheduleDTO)
        {
            var existingTeachingSchedule = await _context.TeachingSchedules.FindAsync(id);
            if (existingTeachingSchedule == null)
            {
                throw new NotImplementedException("TeachingSchedule not exist");
            }
            existingTeachingSchedule.ClassRoom = teachingScheduleDTO.ClassRoom;
            existingTeachingSchedule.TeachTime = teachingScheduleDTO.TeachTime;
            existingTeachingSchedule.TeachDay = teachingScheduleDTO.TeachDay;
            existingTeachingSchedule.Stage = teachingScheduleDTO.Stage;
            existingTeachingSchedule.IDClass = teachingScheduleDTO.IDClass;
            existingTeachingSchedule.IDSubject = teachingScheduleDTO.IDSubject;
            existingTeachingSchedule.IDTeacher = teachingScheduleDTO.IDTeacher;
            _context.TeachingSchedules.Update(existingTeachingSchedule);
            await _context.SaveChangesAsync();
            return existingTeachingSchedule;
        }

        public async Task DeleteTeachingScheduleAsync(int id)
        {
            var existingTeachingSchedule = await _context.TeachingSchedules.SingleOrDefaultAsync(t => t.ID == id);
            if (existingTeachingSchedule == null)
            {
                throw new NotImplementedException("TeachingSchedule not exist");
            }
            _context.TeachingSchedules.Remove(existingTeachingSchedule);
            await _context.SaveChangesAsync();
        }
    }
}
