using Microsoft.AspNetCore.Mvc;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Event()
        {
            return View();
        }
    }
}
