using GECP_FRONTEND_NET_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GECP_FRONTEND_NET_CORE.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

       
    }
}