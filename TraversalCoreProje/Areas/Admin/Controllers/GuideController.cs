using BusinessLayer.Abstract;
using DTOLayer.DTOs.GuideDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")]
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
        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        [HttpGet]
        [Route("AddGuide/{id}")]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        [Route("AddGuide/{id}")]
        public async Task<IActionResult> AddGuide(GuideViewDTO guide, Guide guidelist, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (guide.ImageFile != null)
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extencion = Path.GetExtension(guide.ImageFile.FileName);
                    var imagename = Guid.NewGuid() + extencion;
                    var savelocation = resource + "/wwwroot/userimages/" + imagename;
                    var stream = new FileStream(savelocation, FileMode.Create);
                    guide.Image = imagename;
                    user.İmageUrl = guide.Image;
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
                guidelist.AppUserID = user.Id;
                guide.Name = guidelist.Name;
                guide.InstagramUrl = guidelist.InstagramUrl;
                guide.TwitterUrl = guidelist.TwitterUrl;
                guide.Description = guidelist.Description;
                guide.Description2 = guidelist.Description2;
                _guideService.TInsert(guidelist);
                return RedirectToAction("Index", "Guide");
            }
            else
            {
                // Kullanıcı bulunamadı
                return NotFound();
            }
        }

        [HttpGet]
        [Route("EditGuide/{id}")]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            GuideViewDTO guideViewModel = new GuideViewDTO();
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

        [HttpPost]
        [Route("EditGuide/{id}")]
        public async Task<IActionResult> EditGuide(GuideViewDTO guide, Guide guidelist, int id)
        {
            var values = _guideService.TGetByID(id);
            if (guide.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(guide.ImageFile.FileName);
                var imagename = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                guide.Image = imagename;
                values.Image = guide.Image;
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
            guidelist.AppUserID = values.AppUserID;
            guide.Name = guidelist.Name;
            guide.InstagramUrl = guidelist.InstagramUrl;
            guide.TwitterUrl = guidelist.TwitterUrl;
            guide.Description = guidelist.Description;
            guide.Description2 = guidelist.Description2;
            guide.Status = guidelist.Status;
            _guideService.TUpdate(guidelist);
            return RedirectToAction("Index", "Guide");
        }

        [Route("ChangeToTrue/{id}")]
        public IActionResult ChangeToTrue(int id)
        {
            _guideService.TChangeToTrueByGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }

        [Route("ChangeToFalse/{id}")]
        public IActionResult ChangeToFalse(int id)
        {
            _guideService.TChangeToFalseByGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }

        [HttpGet]
        [Route("GuideList")]
        public async Task<IActionResult> GuideList()
        {
            var userguidelist = await _userManager.GetUsersInRoleAsync("Guide");
            var list = _guideService.TGetListGuideWithAppUser();
            var guideViewModel = new GuideViewDTO
            {
                appUsers = userguidelist.ToList(),
                guides = list
            };
            return View(guideViewModel);
        }
    }
}