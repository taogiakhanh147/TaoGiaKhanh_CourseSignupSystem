using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class SubjectOfStudentService : ISubjectOfStudentService
    {
        private readonly CourseSignupSystemContext _context;

        public SubjectOfStudentService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<SubjectOfStudent>> GetAllSubjectAsync()
        {
            var subjects = await _context.SubjectOfStudents.ToListAsync();
            if (subjects.Count == 0)
            {
                throw new NotImplementedException("Subject not data");
            }
            return subjects;
        }

        public async Task<SubjectOfStudent> GetSubjectsByIdAsync(int id)
        {
            var subject = await _context.SubjectOfStudents.FindAsync(id);
            if (subject == null)
            {
                throw new NotImplementedException("Subject not exist");
            }
            return subject;
        }

        public async Task<SubjectOfStudent> AddSubjectAsync(SubjectOfStudentDTO subjectDTO)
        {
            if (subjectDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            var newSubject = new SubjectOfStudent
            {
                SubjectNO = subjectDTO.SubjectNO,
                SubjectName = subjectDTO.SubjectName,
                IDDepartment = subjectDTO.IDDepartment,
                IDClass = subjectDTO.IDClass
            };
            _context.SubjectOfStudents.Add(newSubject);
            await _context.SaveChangesAsync();
            return newSubject;
        }

        public async Task<SubjectOfStudent> UpdateSubjectAsync(int id, SubjectOfStudentDTO subjectDTO)
        {
            var existingSubject = await _context.SubjectOfStudents.FindAsync(id);
            if (existingSubject == null)
            {
                throw new NotImplementedException("Subject not exist");
            }
            existingSubject.SubjectNO = subjectDTO.SubjectNO;
            existingSubject.SubjectName = subjectDTO.SubjectName;
            existingSubject.IDDepartment = subjectDTO.IDDepartment;
            existingSubject.IDClass = subjectDTO.IDClass;
            _context.SubjectOfStudents.Update(existingSubject);
            await _context.SaveChangesAsync();
            return existingSubject;
        }

        public async Task DeleteSubjectAsync(int id)
        {
            var existingSubject = await _context.SubjectOfStudents.SingleOrDefaultAsync(s => s.ID == id);
            if (existingSubject == null)
            {
                throw new NotImplementedException("Subject not exist");
            }
            _context.SubjectOfStudents.Remove(existingSubject);
            await _context.SaveChangesAsync();
        }
    }
}
