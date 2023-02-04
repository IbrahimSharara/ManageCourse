using Microsoft.AspNetCore.Mvc;

namespace ManageCourses.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}
