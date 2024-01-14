using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Models;

namespace CourseSignupSystemCode.Interface
{
    public interface ICourseService
    {
        public Task<List<Course>> GetAllCourseAsync();

        public Task<Course> GetCoursesByIdAsync(int id);

        public Task<Course> AddCourseAsync(CourseDTO courseDTO);

        public Task<Course> UpdateCourseAsync(int id, CourseDTO courseDTO);

        public Task DeleteCourseAsync(int id);
    }
}
