using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.MemberDashboard
{
    public class _Profileİnformation : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _Profileİnformation(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.username = values.Name + " " + values.SurName;
            ViewBag.tel = values.PhoneNumber;
            ViewBag.Mail = values.Email;
            return View();
        }
    }
}