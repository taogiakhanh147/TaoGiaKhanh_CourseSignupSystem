using CourseSignupSystemCode.DTO;
using CourseSignupSystemCode.Interface;
using iText.Layout.Element;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        private readonly IRevenueService _iRevenueService;

        public RevenueController(IRevenueService iRevenueService)
        {
            _iRevenueService = iRevenueService;
        }

        // Function GetAllInfoStudentHavePaid (GET)
        [HttpGet("GetAllInfoStudentHavePaid")]
        public async Task<List<GetAllInfoStudentHavePaidDTO>> GetAllInfoStudentHavePaid()
        {
            var revenue = await _iRevenueService.GetAllInfoStudentHavePaidAsync();
            return revenue;
        }

        // Function GetAllInfoTeacherSalary (GET)
        [HttpGet("GetAllInfoTeacherSalary")]
        public async Task<List<GetAllInfoTeacherSalaryDTO>> GetAllInfoTeacherSalary()
        {
            var revenue = await _iRevenueService.GetAllInfoTeacherSalaryAsync();
            return revenue;
        }

        // Function GetRevenueStatistics (GET)
        [HttpGet("GetRevenueStatistics")]
        public async Task<GetRevenueStatisticsDTO> GetRevenueStatistics()
        {
            var revenue = await _iRevenueService.GetRevenueStatisticsAsync();
            return revenue;
        }
    }
}
