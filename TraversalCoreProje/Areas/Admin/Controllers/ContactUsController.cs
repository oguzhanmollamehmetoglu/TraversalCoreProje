using BusinessLayer.Abstract;
using DTOLayer.DTOs.ContactDTOs;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ContactUs")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var all = _contactUsService.TGetList();
            return View(all);
        }

        [Route("DeleteContactUs/{id}")]
        public IActionResult DeleteContactUs(int id)
        {
            var values = _contactUsService.TGetByID(id);
            _contactUsService.TDelete(values);
            return RedirectToAction("Dashboard", "Admin");
        }

        [HttpGet]
        [Route("ShowMessage/{id}")]
        public IActionResult ShowMessage(int id)
        {
            var value = _contactUsService.TGetByID(id);
            ReplyMessageDTO replyMessageDTO = new ReplyMessageDTO();
            replyMessageDTO.ReplyId = value.ContactUSId;
            replyMessageDTO.MessageBody = value.MessageBody;
            replyMessageDTO.status = value.ContactUsStatus;
            return View(replyMessageDTO);
        }

        [HttpPost]
        [Route("ShowMessage/{id}")]
        public IActionResult ShowMessage(ReplyMessageDTO replyMessageDTO)
        {
            var user = _contactUsService.TGetByID(replyMessageDTO.ReplyId);
            if (replyMessageDTO.MessageBody != null)
            {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "traversalseyahatturizim@gmail.com");
                mimeMessage.From.Add(mailboxAddressFrom);
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", user.Email);
                mimeMessage.To.Add(mailboxAddressTo);
                var bodybuilder = new BodyBuilder();
                bodybuilder.TextBody = replyMessageDTO.Reply;
                mimeMessage.Body = bodybuilder.ToMessageBody();
                mimeMessage.Subject = "Admin Cevap";
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Connect("smtp.gmail.com", 587, false);
                smtpClient.Authenticate("traversalseyahatturizim@gmail.com", "qguavhgmewqlbwrq");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
                user.ContactUsStatus = false;
                _contactUsService.TUpdate(user);
                return RedirectToAction("Dashboard", "Admin");
            }
            return View();
        }
    }
}