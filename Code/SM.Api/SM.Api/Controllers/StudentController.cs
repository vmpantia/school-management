using Microsoft.AspNetCore.Mvc;
using SM.Api.Contractors;
using SM.Api.Models.Requests;

namespace SM.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _student;
        public StudentController(IStudentService student)
        {
            _student = student;
        }
        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudentsAsync()
        {
            try
            {
                var response = await _student.GetStudentsAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost("SaveStudent")]
        public async Task<IActionResult> SaveStudentAsync(SaveStudentRequest request)
        {
            try
            {
                var response = await _student.SaveStudentAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
