using BusinessLayer.Abstract;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/User")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICommentService _commentService;

        public UserController(IAppUserService appUserService, IReservationService reservationService, UserManager<AppUser> userManager, ICommentService commentService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
            _userManager = userManager;
            _commentService = commentService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _appUserService.TGetList();
            return View(values);
        }

        [Route("AdminProfile/{id}")]
        public async Task<IActionResult> AdminProfile(string id)
        {
            var values = await _userManager.FindByIdAsync(id);
            AdminUserEditViewDTO adminUserEditViewModel = new AdminUserEditViewDTO();
            adminUserEditViewModel.ıd = values.Id;
            adminUserEditViewModel.name = values.Name;
            adminUserEditViewModel.surname = values.SurName;
            adminUserEditViewModel.username = values.UserName;
            adminUserEditViewModel.mail = values.Email;
            adminUserEditViewModel.gender = values.Gender;
            adminUserEditViewModel.phonenumber = values.PhoneNumber;
            adminUserEditViewModel.imgurl = values.İmageUrl;
            adminUserEditViewModel.password = values.PasswordHash;
            return View(adminUserEditViewModel);
        }

        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            _appUserService.TDelete(values);
            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        [Route("EditUser/{id}")]
        public async Task<IActionResult> EditUser(string id)
        {
            var values = await _userManager.FindByIdAsync(id);
            AdminUserEditViewDTO adminUserEditViewModel = new AdminUserEditViewDTO();
            adminUserEditViewModel.ıd = values.Id;
            adminUserEditViewModel.name = values.Name;
            adminUserEditViewModel.surname = values.SurName;
            adminUserEditViewModel.username = values.UserName;
            adminUserEditViewModel.mail = values.Email;
            adminUserEditViewModel.gender = values.Gender;
            adminUserEditViewModel.phonenumber = values.PhoneNumber;
            adminUserEditViewModel.imgurl = values.İmageUrl;
            return View(adminUserEditViewModel);
        }

        [HttpPost]
        [Route("EditUser/{id}")]
        public async Task<IActionResult> EditUser(AdminUserEditViewDTO adminUserEditViewModel)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == adminUserEditViewModel.ıd);
            if (adminUserEditViewModel.ımage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(adminUserEditViewModel.ımage.FileName);
                var imagename = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                adminUserEditViewModel.imgurl = imagename;
                user.İmageUrl = adminUserEditViewModel.imgurl;
                await adminUserEditViewModel.ımage.CopyToAsync(stream);
            }
            user.Name = adminUserEditViewModel.name;
            user.SurName = adminUserEditViewModel.surname;
            user.Email = adminUserEditViewModel.mail;
            user.UserName = adminUserEditViewModel.username;
            user.Gender = adminUserEditViewModel.gender;
            user.PhoneNumber = adminUserEditViewModel.phonenumber;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, adminUserEditViewModel.password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        [Route("CommentUser/{id}")]
        public IActionResult CommentUser(int id)
        {
            var value = _commentService.TGetListCommentWithDestination();
            var comment = value.Where(x => x.AppUserID == id).ToList();
            return View(comment);
        }

        [Route("DeleteComment/{id}")]
        public IActionResult DeleteComment(int id)
        {
            var values = _commentService.TGetByID(id);
            _commentService.TDelete(values);
            return RedirectToAction("Dashboard", "Admin");
        }

        [Route("ReservationUser/{id}")]
        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.TGetListWithReservationByPrevious(id);
            return View(values);
        }

    }
}