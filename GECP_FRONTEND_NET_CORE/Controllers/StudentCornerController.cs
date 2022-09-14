using Microsoft.AspNetCore.Mvc;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class StudentCornerController : Controller
    {
        public IActionResult StudyMaterial()
        {
            return View();
        }
        public IActionResult StudentCouncil()
        {
            return View();
        }
    }
}
