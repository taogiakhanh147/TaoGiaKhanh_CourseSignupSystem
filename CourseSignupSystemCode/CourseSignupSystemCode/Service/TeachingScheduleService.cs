using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

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

            // Kiểm tra xem IDSubject có tồn tại trong bảng Subject không
            var subject = await _context.SubjectOfTeachers
                .Where(s => s.ID == teachingScheduleDTO.IDSubject)
                .Include(s => s.Teachers)
                .FirstOrDefaultAsync();

            if (subject == null)
            {
                throw new Exception("Subject not found");
            }

            // Kiểm tra xem giáo viên có dạy môn có IDSubject không
            var isTeacherTeachingSubject = subject.Teachers.Any(t => t.ID == teachingScheduleDTO.IDTeacher);

            if (!isTeacherTeachingSubject)
            {
                throw new Exception("Teacher is not assigned to teach the specified subject");
            }

            // Tìm lớp thông qua IDClass của bảng Subject
            var classInfo = await _context.Classes
                .Where(c => c.ID == teachingScheduleDTO.IDClass)
                .FirstOrDefaultAsync();

            if (classInfo == null)
            {
                throw new Exception("Class not found");
            }

            // Kiểm tra xem lớp có chứa IDSubject không
            var isSubjectInClass = await _context.Classes
                .Where(c => c.ID == classInfo.ID)
                .SelectMany(c => c.SubjectOfTeachers)
                .AnyAsync(s => s.ID == teachingScheduleDTO.IDSubject);

            if (!isSubjectInClass)
            {
                throw new Exception("Subject not in the specified class");
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
