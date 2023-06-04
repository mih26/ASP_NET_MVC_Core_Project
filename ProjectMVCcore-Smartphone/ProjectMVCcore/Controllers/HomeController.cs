using Microsoft.AspNetCore.Mvc;

namespace ProjectMVCcore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
