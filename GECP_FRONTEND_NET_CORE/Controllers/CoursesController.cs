using Microsoft.AspNetCore.Mvc;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult ComputerScience()
        {
            return View();
        }
        public IActionResult Mechanical()
        {
            return View();
        }
        public IActionResult Electrical()
        {
            return View();
        }
        public IActionResult ElectronicsCommunication()
        {
            return View();
        }
        public IActionResult Civil()
        {
            return View();
        }
    }
}
