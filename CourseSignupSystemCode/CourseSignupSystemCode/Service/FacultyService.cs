using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class FacultyService : IFacultyService
    {
        private readonly CourseSignupSystemContext _context;

        public FacultyService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Faculty>> GetAllFacultyAsync()
        {
            var faculties = await _context.Faculties.ToListAsync();
            if (faculties.Count == 0)
            {
                throw new NotImplementedException("Faculty not data");
            }
            return faculties;
        }

        public async Task<Faculty> GetFacultysByIdAsync(int id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
            if (faculty == null)
            {
                throw new NotImplementedException("Faculty not exist");
            }
            return faculty;
        }

        public async Task<Faculty> AddFacultyAsync(FacultyDTO facultyDTO)
        {
            if (facultyDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            var newFaculty = new Faculty
            {
                FacultyName = facultyDTO.FacultyName
            };
            _context.Faculties.Add(newFaculty);
            await _context.SaveChangesAsync();
            return newFaculty;
        }

        public async Task<Faculty> UpdateFacultyAsync(int id, FacultyDTO FacultyDTO)
        {
            var existingFaculty = await _context.Faculties.FindAsync(id);
            if (existingFaculty == null)
            {
                throw new NotImplementedException("Faculty not exist");
            }
            existingFaculty.FacultyName = FacultyDTO.FacultyName;
            _context.Faculties.Update(existingFaculty);
            await _context.SaveChangesAsync();
            return existingFaculty;
        }

        public async Task DeleteFacultyAsync(int id)
        {
            var existingFaculty = await _context.Faculties.SingleOrDefaultAsync(f => f.ID == id);
            if (existingFaculty == null)
            {
                throw new NotImplementedException("Faculty not exist");
            }
            _context.Faculties.Remove(existingFaculty);
            await _context.SaveChangesAsync();
        }
    }
}
