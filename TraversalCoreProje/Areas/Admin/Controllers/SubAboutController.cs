using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SubAbout")]
    public class SubAboutController : Controller
    {
        private readonly ISubAboutService _subAboutService;

        public SubAboutController(ISubAboutService subAboutService)
        {
            _subAboutService = subAboutService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _subAboutService.TGetList();
            return View(values);
        }

        [HttpGet]
        [Route("EditSubAbout/{id}")]
        public IActionResult EditSubAbout(int id)
        {
            var values = _subAboutService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        [Route("EditSubAbout/{id}")]
        public IActionResult EditSubAbout(SubAbout subAbout)
        {
            _subAboutService.TUpdate(subAbout);
            return RedirectToAction("Index", "SubAbout");
        }
    }
}