using DTOLayer.DTOs.GuideDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Guides.Controllers
{
    [Area("Guides")]
    [Route("Guides/Profile")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            GuideProfileEditViewDTO guideProfileEditViewModel = new GuideProfileEditViewDTO();
            guideProfileEditViewModel.Name = values.Name;
            guideProfileEditViewModel.Surname = values.SurName;
            guideProfileEditViewModel.Mail = values.Email;
            guideProfileEditViewModel.PhoneNumber = values.PhoneNumber;
            guideProfileEditViewModel.İmgUrl = values.İmageUrl;
            return View(guideProfileEditViewModel);
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            GuideProfileEditViewDTO guideProfileEditViewModel = new GuideProfileEditViewDTO();
            guideProfileEditViewModel.Name = values.Name;
            guideProfileEditViewModel.Surname = values.SurName;
            guideProfileEditViewModel.Mail = values.Email;
            guideProfileEditViewModel.PhoneNumber = values.PhoneNumber;
            guideProfileEditViewModel.İmgUrl = values.İmageUrl;
            return View(guideProfileEditViewModel);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(GuideProfileEditViewDTO p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(p.ImageFile.FileName);
                var imagename = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                p.İmgUrl = imagename;
                user.İmageUrl = p.İmgUrl;
                await p.ImageFile.CopyToAsync(stream);
            }
            user.Name = p.Name;
            user.SurName = p.Surname;
            user.PhoneNumber = p.PhoneNumber;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Singin", "Login");
            }
            return View();
        }
    }
}