using Microsoft.AspNetCore.Mvc;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult VisionMission()
        {
            return View();
        }
        public IActionResult Infrastructure()
        {
            return View();
        }
        public IActionResult Principal()
        {
            return View();
        }
        public IActionResult Overview()
        {
            return View();
        }
    }
}
