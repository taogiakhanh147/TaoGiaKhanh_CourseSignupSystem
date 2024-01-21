using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add SQL SERVER
builder.Services.AddDbContext<CourseSignupSystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CourseSignupSystem"));
});

// Add Dependency Injection (Interface)
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IFacultyService, FacultyService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISubjectOfStudentService, SubjectOfStudentService>();
builder.Services.AddScoped<ISubjectOfTeacherService, SubjectOfTeacherService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<ITuitionTypeService, TuitionTypeService>();
builder.Services.AddScoped<ITuitionService, TuitionService>();
builder.Services.AddScoped<IHolidayService, HolidayService>();
builder.Services.AddScoped<ITeachingScheduleService, TeachingScheduleService>();
builder.Services.AddScoped<IScoreTypeService, ScoreTypeService>();
builder.Services.AddScoped<IScoreTypeSubjectService, ScoreTypeSubjectService>();
builder.Services.AddScoped<IResultService, ResultService>();
builder.Services.AddScoped<ISalaryService, SalaryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
