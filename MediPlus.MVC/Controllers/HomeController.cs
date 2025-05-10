using Microsoft.AspNetCore.Mvc;

namespace MediPlus.Core.Abstractions
{
    public sealed class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
