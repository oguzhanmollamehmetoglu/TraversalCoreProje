using BusinessLayer.Abstract;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Reservation")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IDestinationService _destinationService;
        private readonly IAppUserService _appUserService;

        public ReservationController(IReservationService reservationService, IDestinationService destinationService, IAppUserService appUserService)
        {
            _reservationService = reservationService;
            _destinationService = destinationService;
            _appUserService = appUserService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var reservationlist = _reservationService.TGetListReservationWithDestinationAndAppUser();
            var desiredCity = _destinationService.TGetList().Select(x => x.City).ToList();
            var reservationCountForCities = new List<CityReservationInfoViewModel>();
            foreach (var city in desiredCity)
            {
                var reservationCountForCity = reservationlist
                .Where(x => x.Destiantion.City == city)
                .Select(x => x.ReservationID)
                .Distinct()
                .Count();
                var cityId = _destinationService.TGetList().First(x => x.City == city).DestiantionID;
                reservationCountForCities.Add(new CityReservationInfoViewModel
                {
                    CityId = cityId,
                    CityName = city,
                    ReservationCount = reservationCountForCity
                });
            }
            ViewBag.model = reservationCountForCities;
            return View(reservationlist);
        }

        [Route("ReservationList/{id}")]
        public IActionResult ReservationList(int id)
        {
            //Tıklanan şehire göre rezervasyon listesi
            var reservationlist = _reservationService.TGetListReservationWithDestinationAndAppUser()
                                                     .Where(x => x.DestiantionID == id)
                                                     .ToList();
            //Rzervasyon tarihi geçmiş ise durumu güncele
            DateTime dateTime = DateTime.Now;
            foreach (var reservation in reservationlist)
            {
                if (reservation.ReservationDate < dateTime)
                {
                    reservation.Status = "Geçmiş Rezervasyon";
                    _reservationService.TUpdate(reservation);
                }
            }
            return View(reservationlist);
        }

        [Route("ReservationList/DeleteReservation/{id}")]
        public IActionResult DeleteReservation(int id)
        {
            var values = _reservationService.TGetByID(id);
            _reservationService.TDelete(values);
            return RedirectToAction("Index", "Reservation");
        }

        //[Route("Accepted/{id}")]
        //public IActionResult Accepted()
        //{
        //    var reservationacaptedlist = _reservationService.TGetListWithReservationByAccepted();
        //    return RedirectToAction("ReservationList", "Reservation", new { area = "Admin" });
        //}
        //[Route("Previous/{id}")]
        //public IActionResult Previous(int id)
        //{
        //    _reservationService.TGetListWithReservationByPrevious(id);
        //    return RedirectToAction("ReservationList", "Reservation", new { area = "Admin" });
        //}

        [Route("ReservationList/Approval/{id}")]
        public IActionResult Approval(int id)
        {
            var reservation = _reservationService.TGetByID(id);
            reservation.Status = "Onaylandı";
            _reservationService.TUpdate(reservation);

            var user = _appUserService.TGetByID(reservation.AppUserID);
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "traversalseyahatturizim@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", user.Email);
            mimeMessage.To.Add(mailboxAddressTo);
            var bodybuilder = new BodyBuilder();
            bodybuilder.TextBody = $"Sayın {user.Name} {user.SurName},\n\n";
            bodybuilder.TextBody += "Rezervasyonunuz başarıyla onaylandı. Aşağıda detayları bulabilirsiniz:\n\n";
            bodybuilder.TextBody += "Nasıl?\n";
            bodybuilder.TextBody += "Sizlere eşsiz bir seyahat hizmeti sunmak bizim için önemlidir. Kısaca detaylar:\n";
            bodybuilder.TextBody += "- Tur için acentemizde toplanılıp ödeme işlemleri gerçekleştirilecek.\n";
            bodybuilder.TextBody += "- Ödeme işlemi tamamlandıktan sonra arabada yer ayarlanacaktır.\n";
            bodybuilder.TextBody += "- Gerekli sayım yapıldıktan sonra yolculuk başlayacaktır.\n\n";
            bodybuilder.TextBody += "Uyarı!\n";
            bodybuilder.TextBody += "Eğer ödeme işlemi yapmazsanız tura katılamazsınız. Ayrıca, arabaya zamanında gelmeniz önemlidir. Geçikme süreniz en fazla 15-30 dakika arası olabilir.\n\n";
            bodybuilder.TextBody += $"Ne zaman: {reservation.ReservationDate.ToString("f")}\n";
            bodybuilder.TextBody += "Nerede: Traversal acentemiz konumumuzdan bizi bulabilirsiniz.";
            mimeMessage.Body = bodybuilder.ToMessageBody();
            mimeMessage.Subject = "Rezervasyonunuz Onaylandı";
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("traversalseyahatturizim@gmail.com", "qguavhgmewqlbwrq");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return RedirectToAction("Index", "Reservation");
        }
    }
}