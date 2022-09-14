using Microsoft.AspNetCore.Mvc;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class AdmissionController : Controller
    {
        public IActionResult Admission()
        {
            return View();
        }
    }
}
