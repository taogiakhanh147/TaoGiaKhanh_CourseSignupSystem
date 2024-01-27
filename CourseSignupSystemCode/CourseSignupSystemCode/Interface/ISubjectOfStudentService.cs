using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface ISubjectOfStudentService
    {
        public Task<List<SubjectOfStudent>> GetAllSubjectAsync();

        public Task<SubjectOfStudent> GetSubjectsByIdAsync(int id);

        public Task<SubjectOfStudent> AddSubjectAsync(SubjectOfStudentDTO SubjectDTO);

        public Task<SubjectOfStudent> UpdateSubjectAsync(int id, SubjectOfStudentDTO SubjectDTO);

        public Task DeleteSubjectAsync(int id);
    }
}
