using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _contactService.TGetList();
            return View(values);
        }

        [HttpGet]
        [Route("EditContact/{id}")]
        public IActionResult EditContact(int id)
        {
            var values = _contactService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        [Route("EditContact/{id}")]
        public IActionResult EditContact(Contact contact)
        {
            _contactService.TUpdate(contact);
            return RedirectToAction("Index", "Contact");
        }
    }
}