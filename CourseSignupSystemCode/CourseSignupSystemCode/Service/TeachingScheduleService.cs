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
