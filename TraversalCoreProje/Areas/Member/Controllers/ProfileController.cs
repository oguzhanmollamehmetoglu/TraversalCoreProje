using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/Profile")]
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
            UserEditViewDTO userEditViewModel = new UserEditViewDTO();
            userEditViewModel.name = values.Name;
            userEditViewModel.surname = values.SurName;
            userEditViewModel.mail = values.Email;
            userEditViewModel.phonenumber = values.PhoneNumber;
            userEditViewModel.imgurl = values.İmageUrl;
            return View(userEditViewModel);
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewDTO userEditViewModel = new UserEditViewDTO();
            userEditViewModel.name = values.Name;
            userEditViewModel.surname = values.SurName;
            userEditViewModel.mail = values.Email;
            userEditViewModel.phonenumber = values.PhoneNumber;
            userEditViewModel.imgurl = values.İmageUrl;
            return View(userEditViewModel);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(UserEditViewDTO p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.ımage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(p.ımage.FileName);
                var imagename = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                p.imgurl = imagename;
                user.İmageUrl = p.imgurl;
                await p.ımage.CopyToAsync(stream);
            }
            user.Name = p.name;
            user.SurName = p.surname;
            user.PhoneNumber = p.phonenumber;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Singin", "Login");
            }
            return View();
        }
    }
}