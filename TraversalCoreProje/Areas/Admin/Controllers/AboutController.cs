using BusinessLayer.Abstract;
using DTOLayer.DTOs.AboutDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var list = _aboutService.TGetList();
            return View(list);
        }

        [HttpGet]
        [Route("UpdateAbout/{id}")]
        public IActionResult UpdateAbout(int id)
        {
            var list = _aboutService.TGetByID(id);
            AboutViewDTO aboutViewModel = new AboutViewDTO();
            aboutViewModel.AboutID = list.AboutID;
            aboutViewModel.Title = list.Title;
            aboutViewModel.Description = list.Description;
            aboutViewModel.Title2 = list.Title2;
            aboutViewModel.Description2 = list.Description2;
            aboutViewModel.Status = list.Status;
            aboutViewModel.Image1 = list.Image1;
            return View(aboutViewModel);
        }

        [HttpPost]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(About about, AboutViewDTO aboutViewModel)
        {
            if (aboutViewModel.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(aboutViewModel.ImageFile.FileName);
                var imagename = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                about.Image1 = imagename;
                about.Image1 = aboutViewModel.Image1;
                await aboutViewModel.ImageFile.CopyToAsync(stream);
            }
            aboutViewModel.AboutID = about.AboutID;
            aboutViewModel.Title = about.Title;
            aboutViewModel.Description = about.Description;
            aboutViewModel.Title2 = about.Title2;
            aboutViewModel.Description2 = about.Description2;
            aboutViewModel.Status = about.Status;
            _aboutService.TUpdate(about);
            return RedirectToAction("Index", "About");
        }
    }
}