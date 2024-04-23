using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/NewsLater")]
    public class NewsLaterController : Controller
    {
        private readonly INewslaterService _newslaterService;

        public NewsLaterController(INewslaterService newslaterService)
        {
            _newslaterService = newslaterService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var newslater = _newslaterService.TGetList();
            return View(newslater);
        }

        [Route("DeleteNewslater/{id}")]
        public IActionResult DeleteNewslater(int id)
        {
            var newslater = _newslaterService.TGetByID(id);
            _newslaterService.TDelete(newslater);
            return RedirectToAction("Index", "NewsLater");
        }
    }
}