using BusinessLayer.Abstract;
using DTOLayer.DTOs.GuideDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Guides.Controllers
{
    [Area("Guides")]
    [Route("Guides/Guide")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;
        private readonly UserManager<AppUser> _userManager;

        public GuideController(IGuideService guideService, UserManager<AppUser> userManager)
        {
            _guideService = guideService;
            _userManager = userManager;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var val = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _guideService.TGetList().Where(x => x.AppUserID == val.Id);
            foreach (var values in value)
            {
                GuideProfileEditViewDTO guideViewModel = new GuideProfileEditViewDTO();
                guideViewModel.Name = values.Name;
                guideViewModel.GuideID = values.GuideID;
                guideViewModel.InstagramUrl = values.InstagramUrl;
                guideViewModel.TwitterUrl = values.TwitterUrl;
                guideViewModel.Description = values.Description;
                guideViewModel.Description2 = values.Description2;
                guideViewModel.Image = values.Image;
                guideViewModel.GuideListImage = values.GuideListImage;
                return View(guideViewModel);
            }
            return View();
        }

        [HttpGet]
        [Route("EditGuide")]
        public async Task<IActionResult> EditGuide()
        {
            var val = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _guideService.TGetList().Where(x => x.AppUserID == val.Id);
            foreach (var values in value)
            {
                GuideProfileEditViewDTO guideViewModel = new GuideProfileEditViewDTO();
                guideViewModel.Name = values.Name;
                guideViewModel.GuideID = values.GuideID;
                guideViewModel.InstagramUrl = values.InstagramUrl;
                guideViewModel.TwitterUrl = values.TwitterUrl;
                guideViewModel.Description = values.Description;
                guideViewModel.Description2 = values.Description2;
                guideViewModel.Image = values.Image;
                guideViewModel.GuideListImage = values.GuideListImage;
                return View(guideViewModel);
            }
            return View();
        }

        [HttpPost]
        [Route("EditGuide")]
        public async Task<IActionResult> EditGuide(GuideProfileEditViewDTO guide, Guide guidelist)
        {
            var val = await _userManager.FindByNameAsync(User.Identity.Name);
            if (guide.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(guide.ImageFile.FileName);
                var imagename = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                guide.Image = imagename;
                guidelist.Image = guide.Image;
                await guide.ImageFile.CopyToAsync(stream);
            }
            if (guide.ImageFile2 != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(guide.ImageFile2.FileName);
                var imagename = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                guide.GuideListImage = imagename;
                guidelist.GuideListImage = guide.GuideListImage;
                await guide.ImageFile2.CopyToAsync(stream);
            }
            guidelist.GuideID = guide.GuideID;
            guidelist.AppUserID = val.Id;
            guide.Name = guidelist.Name;
            guide.InstagramUrl = guidelist.InstagramUrl;
            guide.TwitterUrl = guidelist.TwitterUrl;
            guide.Description = guidelist.Description;
            guide.Description2 = guidelist.Description2;
            guide.Status = guidelist.Status;
            _guideService.TUpdate(guidelist);
            return RedirectToAction("Index", "Guide");
        }
    }
}