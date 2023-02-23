using Microsoft.AspNetCore.Mvc;

namespace SM.Web.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
