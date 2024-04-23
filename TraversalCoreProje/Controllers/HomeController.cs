using DTOLayer.DTOs.ErrorDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index sayfası çağrıldı.");
            _logger.LogError("log error çağrıldı");
            return View();
        }

        public IActionResult Privacy()
        {
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            _logger.LogInformation(dateTime + "Privacy sayfası çağrıldı.");
            return View();
        }

        public IActionResult Test()
        {
            _logger.LogInformation("Test sayfası çağrıldı.");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorPageDTO { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}