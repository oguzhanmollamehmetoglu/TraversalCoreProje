using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SocialContact")]
    public class SocialContactController : Controller
    {
        private readonly ISocialContactService _socialContactService;

        public SocialContactController(ISocialContactService socialContactService)
        {
            _socialContactService = socialContactService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var value = _socialContactService.TGetList();
            return View(value);
        }

        [HttpGet]
        [Route("EditContact/{id}")]
        public IActionResult EditContact(int id)
        {
            var values = _socialContactService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        [Route("EditContact/{id}")]
        public IActionResult EditContact(SocialContact socialContact)
        {
            if (socialContact.Url != null)
            {
                var values = _socialContactService.TGetByID(socialContact.SocialContactId);
                socialContact.Name = values.Name;
                socialContact.İcon = values.İcon;
                socialContact.Status = values.Status;
                _socialContactService.TUpdate(socialContact);
                return RedirectToAction("Index", "SocialContact");
            }
            return RedirectToAction("EditContact", "SocialContact");
        }

        [Route("ChangeToTrue/{id}")]
        public IActionResult ChangeToTrue(int id)
        {
            _socialContactService.TChangeToTrueBySocialContact(id);
            return RedirectToAction("Index", "SocialContact", new { area = "Admin" });
        }
        [Route("ChangeToFalse/{id}")]
        public IActionResult ChangeToFalse(int id)
        {
            _socialContactService.TChangeToFalseBySocialContact(id);
            return RedirectToAction("Index", "SocialContact", new { area = "Admin" });
        }
    }
}