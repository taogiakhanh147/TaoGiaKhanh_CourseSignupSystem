using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Data
{
    public class CourseSignupSystemContext:DbContext
    {
        public CourseSignupSystemContext(DbContextOptions<CourseSignupSystemContext> opt) : base(opt)
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TeachingSchedule> TeachingSchedules { get; set; }
        public DbSet<SubjectOfStudent> SubjectOfStudents { get; set; }
        public DbSet<SubjectOfTeacher> SubjectOfTeachers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Tuition> Tuitions { get; set; }
        public DbSet<TuitionType> TuitionTypes { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ScoreTypeSubject> ScoreTypeSubjects { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ScoreType> ScoreTypes { get; set; }
    }
}
