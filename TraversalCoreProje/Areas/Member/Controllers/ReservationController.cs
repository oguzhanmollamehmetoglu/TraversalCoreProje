using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/Reservation")]
    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());
        ReservationManager reservationManager = new ReservationManager(new EFReservationDal());
        private readonly UserManager<AppUser> _userManager;
        private readonly IReservationService _reservationService;
        private readonly IDestinationService _destinationService;

        public ReservationController(UserManager<AppUser> userManager, IReservationService reservationService, IDestinationService destinationService)
        {
            _userManager = userManager;
            _reservationService = reservationService;
            _destinationService = destinationService;
        }

        [Route("MyCurrentReservation")]
        public async Task<IActionResult> MyCurrentReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.TGetListWithReservationByAccepted(values.Id);
            return View(valuesList);
        }

        [Route("MyOldReservation")]
        public async Task<IActionResult> MyOldReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.TGetListWithReservationByPrevious(values.Id);
            return View(valuesList);
        }

        [Route("MyApprovalReservation")]
        public async Task<IActionResult> MyApprovalReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.TGetListWithReservationByWaitAprroval(values.Id);
            return View(valuesList);
        }

        [HttpGet]
        [Route("NewReservation")]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in destinationManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestiantionID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            List<SelectListItem> values2 = (from x in destinationManager.TGetList()
                                            select new SelectListItem
                                            {
                                                Text = x.Date.ToString(),
                                                Value = x.DestiantionID.ToString()
                                            }).ToList();
            ViewBag.v2 = values2;
            return View();
        }

        [HttpPost]
        [Route("NewReservation")]
        public async Task<IActionResult> NewReservation(Reservation p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            p.AppUserID = user.Id;
            p.Status = "Onay Bekliyor";
            _reservationService.TInsert(p);
            return RedirectToAction("MyApprovalReservation", "Reservation");
        }
    }
}