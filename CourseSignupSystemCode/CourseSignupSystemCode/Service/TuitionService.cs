using CourseSignupSystemCode.Data;
using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using CourseSignupSystemCode.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystemCode.Service
{
    public class TuitionService : ITuitionService
    {
        private readonly CourseSignupSystemContext _context;

        public TuitionService(CourseSignupSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Tuition>> GetAllTuitionAsync()
        {
            var tuitions = await _context.Tuitions.ToListAsync();
            if (tuitions.Count == 0)
            {
                throw new NotImplementedException("Tuition not data");
            }
            return tuitions;
        }

        public async Task<Tuition> GetTuitionsByIdAsync(int id)
        {
            var tuition = await _context.Tuitions.FindAsync(id);
            if (tuition == null)
            {
                throw new NotImplementedException("Tuition not exist");
            }
            return tuition;
        }

        public async Task<Tuition> AddTuitionAsync(TuitionDTO tuitionDTO)
        {
            if (tuitionDTO == null)
            {
                throw new NotImplementedException("Please enter complete information");
            }
            // Kiểm tra xem IDClass trong bảng Tuition có trùng khớp với IDClass trong bảng Student không
            var student = await _context.Students.FindAsync(tuitionDTO.IDStudent);
            if(student == null || student.IDClass != tuitionDTO.IDClass)
            {
                throw new NotImplementedException("Student is not in this class!");
            }
            var newTuition = new Tuition
            {
                TuitionFee = tuitionDTO.TuitionFee,
                Discount = tuitionDTO.Discount,
                Surcharge = tuitionDTO.Surcharge,
                TotalTuition = ((tuitionDTO.TuitionFee + tuitionDTO.Surcharge) - (tuitionDTO.Discount / 100.0 * tuitionDTO.TuitionFee)),
                Note = tuitionDTO.Note,
                IDClass = tuitionDTO.IDClass,
                IDStudent = tuitionDTO.IDStudent,
                IDTuitionType = tuitionDTO.IDTuitionType,
            };
            _context.Tuitions.Add(newTuition);
            await _context.SaveChangesAsync();
            return newTuition;
        }

        public async Task<Tuition> UpdateTuitionAsync(int id, TuitionDTO tuitionDTO)
        {
            var existingTuition = await _context.Tuitions.FindAsync(id);
            if (existingTuition == null)
            {
                throw new NotImplementedException("Tuition not exist");
            }
            // Kiểm tra xem IDClass trong bảng Tuition có trùng khớp với IDClass trong bảng Student không
            var student = await _context.Students.FindAsync(tuitionDTO.IDStudent);
            if (student == null || student.IDClass != tuitionDTO.IDClass)
            {
                throw new NotImplementedException("Student is not in this class!");
            }
            existingTuition.TuitionFee = tuitionDTO.TuitionFee;
            existingTuition.Discount = tuitionDTO.Discount;
            existingTuition.Surcharge = tuitionDTO.Surcharge;
            existingTuition.TotalTuition = ((tuitionDTO.TuitionFee + tuitionDTO.Surcharge) - (tuitionDTO.Discount / 100.0 * tuitionDTO.TuitionFee));
            existingTuition.Note = tuitionDTO.Note;
            existingTuition.IDClass = tuitionDTO.IDClass;
            existingTuition.IDStudent = tuitionDTO.IDStudent;
            existingTuition.IDTuitionType = tuitionDTO.IDTuitionType;
            _context.Tuitions.Update(existingTuition);
            await _context.SaveChangesAsync();
            return existingTuition;
        }

        public async Task DeleteTuitionAsync(int id)
        {
            var existingTuition = await _context.Tuitions.SingleOrDefaultAsync(t => t.ID == id);
            if (existingTuition == null)
            {
                throw new NotImplementedException("Tuition not exist");
            }
            _context.Tuitions.Remove(existingTuition);
            await _context.SaveChangesAsync();
        }
    }
}
