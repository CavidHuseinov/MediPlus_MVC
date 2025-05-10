using MediPlus.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MediPlus.UI.Areas.Admin.Controllers
{
    [Area("Dashboard")]
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
