using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class SubjectOfTeacherService : ISubjectOfTeacherService
    {
        private readonly CourseSignupSystemContext _context;

        public SubjectOfTeacherService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<SubjectOfTeacher>> GetAllSubjectAsync()
        {
            var subjects = await _context.SubjectOfTeachers.ToListAsync();
            if (subjects.Count == 0)
            {
                throw new NotImplementedException("Subject not data");
            }
            return subjects;
        }

        public async Task<SubjectOfTeacher> GetSubjectsByIdAsync(int id)
        {
            var subject = await _context.SubjectOfTeachers.FindAsync(id);
            if (subject == null)
            {
                throw new NotImplementedException("Subject not exist");
            }
            return subject;
        }

        public async Task<SubjectOfTeacher> AddSubjectAsync(SubjectOfTeacherDTO subjectDTO)
        {
            if (subjectDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }

            var newSubject = new SubjectOfTeacher
            {
                SubjectNO = subjectDTO.SubjectNO,
                SubjectName = subjectDTO.SubjectName,
                IDDepartment = subjectDTO.IDDepartment,
                IDClass = subjectDTO.IDClass
            };
            _context.SubjectOfTeachers.Add(newSubject);
            await _context.SaveChangesAsync();
            return newSubject;
        }

        public async Task<SubjectOfTeacher> UpdateSubjectAsync(int id, SubjectOfTeacherDTO subjectDTO)
        {
            var existingSubject = await _context.SubjectOfTeachers.FindAsync(id);
            if (existingSubject == null)
            {
                throw new NotImplementedException("Subject not exist");
            }
            existingSubject.SubjectNO = subjectDTO.SubjectNO;
            existingSubject.SubjectName = subjectDTO.SubjectName;
            existingSubject.IDDepartment = subjectDTO.IDDepartment;
            existingSubject.IDClass = subjectDTO.IDClass;
            _context.SubjectOfTeachers.Update(existingSubject);
            await _context.SaveChangesAsync();
            return existingSubject;
        }

        public async Task DeleteSubjectAsync(int id)
        {
            var existingSubject = await _context.SubjectOfTeachers.SingleOrDefaultAsync(s => s.ID == id);
            if (existingSubject == null)
            {
                throw new NotImplementedException("Subject not exist");
            }
            _context.SubjectOfTeachers.Remove(existingSubject);
            await _context.SaveChangesAsync();
        }
    }
}
