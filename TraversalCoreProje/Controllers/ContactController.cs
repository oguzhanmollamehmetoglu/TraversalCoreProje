using BusinessLayer.Abstract;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IContactService _contactService;

        public ContactController(IContactUsService contactUsService, IContactService contactService)
        {
            _contactUsService = contactUsService;
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // İletişim bilgilerini almak için bir metot örneği
            var contacts = _contactService.TGetList();
            // Örnek bir Contact nesnesi oluşturuyoruz (gerekirse)
            var newContact = new Contact();
            // ViewData'ya ContactModel ve ContactList'i ekliyoruz
            ViewData["ContactModel"] = newContact;
            ViewData["ContactList"] = contacts;
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessageDTO model)
        {
            if (ModelState.IsValid)
            {
                _contactUsService.TInsert(new ContactUS()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Subject = model.Subject,
                    MessageBody = model.MessageBody,
                    ContactUsStatus = true,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index", "Default");
            }
            return View(model);
        }
    }
}