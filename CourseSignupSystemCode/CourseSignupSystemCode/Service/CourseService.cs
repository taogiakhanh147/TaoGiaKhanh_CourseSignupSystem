using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class CourseService : ICourseService
    {
        private readonly CourseSignupSystemContext _context;

        public CourseService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllCourseAsync()
        {
            var courses = await _context.Courses.ToListAsync();
            if (courses.Count == 0)
            {
                throw new NotImplementedException("Course not data");
            }
            return courses;
        }

        public async Task<Course> GetCoursesByIdAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                throw new NotImplementedException("Course not exist");
            }
            return course;
        }

        public async Task<Course> AddCourseAsync(CourseDTO courseDTO)
        {
            if (courseDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            var newCourse = new Course
            {
                CourseNO = courseDTO.CourseNO,
                CourseName = courseDTO.CourseName,
                CourseStartDate = courseDTO.CourseStartDate,
                CourseEndDate = courseDTO.CourseEndDate
            };
            _context.Courses.Add(newCourse);
            await _context.SaveChangesAsync();
            return newCourse;
        }

        public async Task<Course> UpdateCourseAsync(int id, CourseDTO courseDTO)
        {
            var existingCourse = await _context.Courses.FindAsync(id);
            if (existingCourse == null)
            {
                throw new NotImplementedException("Course not exist");
            }
            existingCourse.CourseNO = courseDTO.CourseNO;
            existingCourse.CourseName = courseDTO.CourseName;
            existingCourse.CourseStartDate = courseDTO.CourseStartDate;
            existingCourse.CourseEndDate = courseDTO.CourseEndDate;
            _context.Courses.Update(existingCourse);
            await _context.SaveChangesAsync();
            return existingCourse;
        }

        public async Task DeleteCourseAsync(int id)
        {
            var existingCourse = await _context.Courses.SingleOrDefaultAsync(c => c.ID == id);
            if (existingCourse == null)
            {
                throw new NotImplementedException("Course not exist");
            }
            _context.Courses.Remove(existingCourse);
            await _context.SaveChangesAsync();
        }
    }
}
