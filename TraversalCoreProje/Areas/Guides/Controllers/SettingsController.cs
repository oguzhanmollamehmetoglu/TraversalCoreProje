using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Guides.Controllers
{
    [Area("Guides")]
    [Route("Guides/Settings")]
    public class SettingsController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
