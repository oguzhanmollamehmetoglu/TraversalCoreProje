using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;
        GuideManager guideManager = new GuideManager(new EFGuideDal());

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = guideManager.TGetList();
            return View(values);
        }

        public IActionResult GuideDetails(int id)
        {
            var list = _guideService.TGetList().Where(x => x.GuideID == id).ToList();
            return View(list);
        }
    }
}