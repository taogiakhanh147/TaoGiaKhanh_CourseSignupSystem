using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface ISubjectOfTeacherService
    {
        public Task<List<SubjectOfTeacher>> GetAllSubjectAsync();

        public Task<SubjectOfTeacher> GetSubjectsByIdAsync(int id);

        public Task<SubjectOfTeacher> AddSubjectAsync(SubjectOfTeacherDTO subjectOfTeacherDTO);

        public Task<SubjectOfTeacher> UpdateSubjectAsync(int id, SubjectOfTeacherDTO subjectOfTeacherDTO);

        public Task DeleteSubjectAsync(int id);
    }
}
