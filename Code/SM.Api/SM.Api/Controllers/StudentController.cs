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

        [HttpPost("SaveStudent")]
        public async Task<IActionResult> SaveStudentAsync(SaveStudentRequest request)
        {
            try
            {
                await _student.SaveStudent(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }
    }
}
