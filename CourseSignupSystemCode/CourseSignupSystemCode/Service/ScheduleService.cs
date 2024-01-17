using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class ScheduleService : IScheduleService
    {
        private readonly CourseSignupSystemContext _context;

        public ScheduleService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Schedule>> GetAllScheduleAsync()
        {
            var schedules = await _context.Schedules.ToListAsync();
            if (schedules.Count == 0)
            {
                throw new NotImplementedException("Schedule not data");
            }
            return schedules;
        }

        public async Task<Schedule> GetSchedulesByIdAsync(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                throw new NotImplementedException("Schedule not exist");
            }
            return schedule;
        }

        public async Task<Schedule> AddScheduleAsync(ScheduleDTO scheduleDTO)
        {
            if (scheduleDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }

            // Kiểm tra học sinh đó có tồn tại không
            var student = await _context.Students
                        .Include(s => s.Class)
                        .ThenInclude(c => c.SubjectOfStudents)
                        .FirstOrDefaultAsync(s => s.ID == scheduleDTO.IDStudent);
            if (student == null)
            {
                throw new NotImplementedException("Student not exist");
            }

            // Kiểm tra xem môn học nhập vào có thuộc trong lớp mà học sinh học không
            var subjectInClass = student.Class?.SubjectOfStudents.FirstOrDefault(s => s.ID == scheduleDTO.IDSubject);
            if (subjectInClass == null)
            {
                throw new NotImplementedException("Subject is not in the student's class");
            }

            var newSchedule = new Schedule
            {
                ClassRoom = scheduleDTO.ClassRoom,
                StudyTime = scheduleDTO.StudyTime,
                StudyDay = scheduleDTO.StudyDay,
                Stage = scheduleDTO.Stage,
                IDSubject = scheduleDTO.IDSubject,
                IDStudent = scheduleDTO.IDStudent
            };
            _context.Schedules.Add(newSchedule);
            await _context.SaveChangesAsync();
            return newSchedule;
        }

        public async Task<Schedule> UpdateScheduleAsync(int id, ScheduleDTO scheduleDTO)
        {
            var existingSchedule = await _context.Schedules.FindAsync(id);
            if (existingSchedule == null)
            {
                throw new NotImplementedException("Schedule not exist");
            }
            // Kiểm tra học sinh đó có tồn tại không
            var student = await _context.Students
                        .Include(s => s.Class)
                        .ThenInclude(c => c.SubjectOfStudents)
                        .FirstOrDefaultAsync(s => s.ID == scheduleDTO.IDStudent);
            if (student == null)
            {
                throw new NotImplementedException("Student not exist");
            }

            // Kiểm tra xem môn học nhập vào có thuộc trong lớp mà học sinh học không
            var subjectInClass = student.Class?.SubjectOfStudents.FirstOrDefault(s => s.ID == scheduleDTO.IDSubject);
            if (subjectInClass == null)
            {
                throw new NotImplementedException("Subject is not in the student's class");
            }
            existingSchedule.ClassRoom = scheduleDTO.ClassRoom;
            existingSchedule.StudyTime = scheduleDTO.StudyTime;
            existingSchedule.StudyDay = scheduleDTO.StudyDay;
            existingSchedule.Stage = scheduleDTO.Stage;
            existingSchedule.IDSubject = scheduleDTO.IDSubject;
            existingSchedule.IDStudent = scheduleDTO.IDStudent;
            _context.Schedules.Update(existingSchedule);
            await _context.SaveChangesAsync();
            return existingSchedule;
        }

        public async Task DeleteScheduleAsync(int id)
        {
            var existingSchedule = await _context.Schedules.SingleOrDefaultAsync(s => s.ID == id);
            if (existingSchedule == null)
            {
                throw new NotImplementedException("Schedule not exist");
            }
            _context.Schedules.Remove(existingSchedule);
            await _context.SaveChangesAsync();
        }
    }
}
