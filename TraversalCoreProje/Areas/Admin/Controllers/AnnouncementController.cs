using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Announcement")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly INewslaterService _newslaterService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, INewslaterService newslaterService, IMapper mapper)
        {
            _announcementService = announcementService;
            _newslaterService = newslaterService;
            _mapper = mapper;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            //List<Announcement> announcements = _announcementService.TGetList();
            //List<AnnouncementListViewModel> list = new List<AnnouncementListViewModel>();
            //foreach (var item in announcements)
            //{
            //    AnnouncementListViewModel model = new AnnouncementListViewModel();
            //    model.ID = item.AnnouncementID;
            //    model.Title = item.Title;
            //    model.Content = item.Content;

            //    list.Add(model);
            //}
            //return View(list);
            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetList());
            return View(values);
        }

        [HttpGet]
        [Route("AddAnnouncement")]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        [Route("AddAnnouncement")]
        public IActionResult AddAnnouncement(AnnouncementAddDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TInsert(new Announcement()
                {
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index", "Announcement");
            }
            return View(model);
        }

        [Route("DeleteAnnouncement/{id}")]
        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcementService.TGetByID(id);
            _announcementService.TDelete(values);
            return RedirectToAction("Index", "Announcement");
        }

        [HttpGet]
        [Route("UpdateAnnouncement/{id}")]
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.TGetByID(id));
            return View(values);
        }

        [HttpPost]
        [Route("UpdateAnnouncement")]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TUpdate(new Announcement()
                {
                    AnnouncementID = model.AnnouncementID,
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index", "Announcement");
            }
            return View(model);
        }

        [HttpGet]
        [Route("SendMail/{id}")]
        public IActionResult SendMail(int id)
        {
            var announcement = _announcementService.TGetByID(id);
            var newslater = _newslaterService.TGetList();
            foreach (var item in newslater)
            {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "traversalseyahatturizim@gmail.com");
                mimeMessage.From.Add(mailboxAddressFrom);
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", item.Mail);
                mimeMessage.To.Add(mailboxAddressTo);
                var bodybuilder = new BodyBuilder();
                bodybuilder.TextBody = announcement.Content;
                mimeMessage.Body = bodybuilder.ToMessageBody();
                mimeMessage.Subject = announcement.Title;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Connect("smtp.gmail.com", 587, false);
                smtpClient.Authenticate("traversalseyahatturizim@gmail.com", "qguavhgmewqlbwrq");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
            }
            return RedirectToAction("Index", "Announcement");
        }
    }
}