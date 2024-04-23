using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly INewslaterService _newslaterService;

        public DefaultController(INewslaterService newslaterService)
        {
            _newslaterService = newslaterService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMail(Newslater newslater)
        {
            _newslaterService.TInsert(newslater);
            return RedirectToAction("Index", "Default");
        }
    }
}