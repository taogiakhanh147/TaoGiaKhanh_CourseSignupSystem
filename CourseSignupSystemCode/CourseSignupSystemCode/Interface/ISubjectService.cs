using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface ISubjectService
    {
        public Task<List<Subject>> GetAllSubjectAsync();

        public Task<Subject> GetSubjectsByIdAsync(int id);

        public Task<Subject> AddSubjectAsync(SubjectDTO SubjectDTO);

        public Task<Subject> UpdateSubjectAsync(int id, SubjectDTO SubjectDTO);

        public Task DeleteSubjectAsync(int id);
    }
}
