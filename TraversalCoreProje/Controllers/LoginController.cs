using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Singup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Singup(AppUserRegisterDTO p)
        {
            try
            {
                AppUser appUser = new AppUser()
                {
                    Name = p.Name,
                    SurName = p.SurName,
                    Email = p.Email,
                    UserName = p.UserName,
                    Gender = p.Gender,
                    İmageUrl = "url",
                };
                if (p.Password == p.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, p.Password);
                    if (result.Succeeded)
                    {
                        // Kullanıcı başarıyla kaydedildi, varsayılan rolü atayalım
                        await _userManager.AddToRoleAsync(appUser, "Member");
                        return RedirectToAction("Singin");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                return View(p);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Singin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Singin(AppUserSinginDTO p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                    if (result.Succeeded)
                    {
                        var user = await _userManager.FindByNameAsync(p.username);
                        var roles = await _userManager.GetRolesAsync(user);

                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Dashboard", "Admin", new { area = "Admin" });
                        }
                        else if (roles.Contains("Member"))
                        {
                            return RedirectToAction("Dashboard", "Member", new { area = "Member" });
                        }
                        else if (roles.Contains("Guide"))
                        {
                            return RedirectToAction("Dashboard", "Guides", new { area = "Guides" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Default");
                        }
                    }
                    else
                    {
                        return RedirectToAction("Singin", "Login");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [Authorize] // Sadece oturum açmış kullanıcılar logout yapabilir
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); // Oturumu sonlandır
            return RedirectToAction("Index", "Default"); // Anasayfaya yönlendir
        }
    }
}