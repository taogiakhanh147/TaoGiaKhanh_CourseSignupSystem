using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly CourseSignupSystemContext _context;

        public SubjectService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetAllSubjectAsync()
        {
            var subjects = await _context.Subjects.ToListAsync();
            if (subjects.Count == 0)
            {
                throw new NotImplementedException("Subject not data");
            }
            return subjects;
        }

        public async Task<Subject> GetSubjectsByIdAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                throw new NotImplementedException("Subject not exist");
            }
            return subject;
        }

        public async Task<Subject> AddSubjectAsync(SubjectDTO subjectDTO)
        {
            if (subjectDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            var newSubject = new Subject
            {
                SubjectNO = subjectDTO.SubjectNO,
                SubjectName = subjectDTO.SubjectName,
                IDDepartment = subjectDTO.IDDepartment
            };
            _context.Subjects.Add(newSubject);
            await _context.SaveChangesAsync();
            return newSubject;
        }

        public async Task<Subject> UpdateSubjectAsync(int id, SubjectDTO subjectDTO)
        {
            var existingSubject = await _context.Subjects.FindAsync(id);
            if (existingSubject == null)
            {
                throw new NotImplementedException("Subject not exist");
            }
            existingSubject.SubjectNO = subjectDTO.SubjectNO;
            existingSubject.SubjectName = subjectDTO.SubjectName;
            existingSubject.IDDepartment = subjectDTO.IDDepartment;
            _context.Subjects.Update(existingSubject);
            await _context.SaveChangesAsync();
            return existingSubject;
        }

        public async Task DeleteSubjectAsync(int id)
        {
            var existingSubject = await _context.Subjects.SingleOrDefaultAsync(s => s.ID == id);
            if (existingSubject == null)
            {
                throw new NotImplementedException("Subject not exist");
            }
            _context.Subjects.Remove(existingSubject);
            await _context.SaveChangesAsync();
        }
    }
}
