using Microsoft.AspNetCore.Mvc;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}
