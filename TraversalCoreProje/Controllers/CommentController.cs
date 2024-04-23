using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EFCommentDal());

        private readonly UserManager<AppUser> _userManager;

        public CommentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            //ViewBag.destID = id;
            //var values = await _userManager.FindByNameAsync(User.Identity.Name);
            //ViewBag.AppuserID = values.Id;
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.CommentUser = value.UserName;
            commentManager.TAdd(p);
            return RedirectToAction("Index","Destination");
        }
    }
}