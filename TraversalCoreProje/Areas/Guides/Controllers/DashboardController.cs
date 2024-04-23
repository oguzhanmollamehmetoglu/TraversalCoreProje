using BusinessLayer.Abstract;
using DTOLayer.DTOs.GuideDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Guides.Controllers
{
    [Area("Guides")]
    [AllowAnonymous]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IDestinationService _destinationService;
        private readonly IGuideService _guideService;

        public DashboardController(UserManager<AppUser> userManager, IDestinationService destinationService, IGuideService guideService)
        {
            _userManager = userManager;
            _destinationService = destinationService;
            _guideService = guideService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new GuideViewDTO
            {
                Destiantion = _destinationService.TGetLastFourDestination(),
                guides = _guideService.TGetLastSixGuide()
            };

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = values.Name + " " + values.SurName;
            ViewBag.İmgUrl = values.İmageUrl;
            ViewBag.tel = values.PhoneNumber;
            ViewBag.mail = values.Email;
            return View(model);
        }
    }
}