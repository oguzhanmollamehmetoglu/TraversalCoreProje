using BusinessLayer.Abstract;
using DTOLayer.DTOs.DestinationsDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Destination")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IGuideService _guideService;

        public DestinationController(IDestinationService destinationService, IGuideService guideService)
        {
            _destinationService = destinationService;
            _guideService = guideService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }

        [HttpGet]
        [Route("AddDestination")]
        public IActionResult AddDestination()
        {
            var list = _guideService.TGetList();
            DestinationViewDTO viewModel = new DestinationViewDTO();
            viewModel.guides = list;
            return View(viewModel);
        }

        [HttpPost]
        [Route("AddDestination")]
        public async Task<IActionResult> AddDestination(DestinationViewDTO destinationViewModel, Destination destination)
        {
            var list = _guideService.TGetList();
            if (destinationViewModel.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(destinationViewModel.ImageFile.FileName);
                var imagename = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                destinationViewModel.Image = imagename;
                destination.Image = destinationViewModel.Image;
                await destinationViewModel.ImageFile.CopyToAsync(stream);
            }
            if (destinationViewModel.CoverImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(destinationViewModel.CoverImageFile.FileName);
                var imagename = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                destinationViewModel.CoverImage = imagename;
                destination.CoverImage = destinationViewModel.CoverImage;
                await destinationViewModel.CoverImageFile.CopyToAsync(stream);
            }
            if (destinationViewModel.Image2File != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(destinationViewModel.Image2File.FileName);
                var imagename = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                destinationViewModel.Image2 = imagename;
                destination.Image2 = destinationViewModel.Image2;
                await destinationViewModel.Image2File.CopyToAsync(stream);
            }
            destination.DestiantionID = destinationViewModel.DestiantionID;
            destinationViewModel.guides = list;
            destination.GuideID = destinationViewModel.GuideID;
            destination.City = destinationViewModel.City;
            destination.DayNight = destinationViewModel.DayNight;
            destination.Price = destinationViewModel.Price;
            destination.Description = destinationViewModel.Description;
            destination.Capacity = destinationViewModel.Capacity;
            destination.Status = destinationViewModel.Status;
            destination.Details1 = destinationViewModel.Details1;
            destination.Details2 = destinationViewModel.Details2;
            destination.Date = destinationViewModel.Date;
            _destinationService.TInsert(destination);
            return RedirectToAction("Index", "Destination");
        }

        [Route("DeleteDestination/{id}")]
        public IActionResult DeleteDestination(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return RedirectToAction("Index", "Destination");
        }

        [HttpGet]
        [Route("UpdateDestination/{id}")]
        public IActionResult UpdateDestination(int id)
        {
            var list = _guideService.TGetList();
            var values = _destinationService.TGetByID(id);
            DestinationViewDTO destinationViewModel = new DestinationViewDTO();
            destinationViewModel.guides = list;
            destinationViewModel.DestiantionID = values.DestiantionID;
            destinationViewModel.GuideID = values.GuideID;
            destinationViewModel.City = values.City;
            destinationViewModel.DayNight = values.DayNight;
            destinationViewModel.Price = values.Price;
            destinationViewModel.Description = values.Description;
            destinationViewModel.Capacity = values.Capacity;
            destinationViewModel.Status = values.Status;
            destinationViewModel.Details1 = values.Details1;
            destinationViewModel.Details2 = values.Details2;
            destinationViewModel.Date = values.Date;
            destinationViewModel.Image = values.Image;
            destinationViewModel.Image2 = values.Image2;
            destinationViewModel.CoverImage = values.CoverImage;
            return View(destinationViewModel);
        }

        [HttpPost]
        [Route("UpdateDestination/{id}")]
        public async Task<IActionResult> UpdateDestination(DestinationViewDTO destinationViewModel, Destination destination)
        {
            var list = _guideService.TGetList();
            if (destinationViewModel.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(destinationViewModel.ImageFile.FileName);
                var imagename = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                destinationViewModel.Image = imagename;
                destination.Image = destinationViewModel.Image;
                await destinationViewModel.ImageFile.CopyToAsync(stream);
            }
            if (destinationViewModel.CoverImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(destinationViewModel.CoverImageFile.FileName);
                var imagename = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                destinationViewModel.CoverImage = imagename;
                destination.CoverImage = destinationViewModel.CoverImage;
                await destinationViewModel.CoverImageFile.CopyToAsync(stream);
            }
            if (destinationViewModel.Image2File != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(destinationViewModel.Image2File.FileName);
                var imagename = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                destinationViewModel.Image2 = imagename;
                destination.Image2 = destinationViewModel.Image2;
                await destinationViewModel.Image2File.CopyToAsync(stream);
            }
            destination.DestiantionID = destinationViewModel.DestiantionID;
            destinationViewModel.guides = list;
            destination.GuideID = destinationViewModel.GuideID;
            destination.City = destinationViewModel.City;
            destination.DayNight = destinationViewModel.DayNight;
            destination.Price = destinationViewModel.Price;
            destination.Description = destinationViewModel.Description;
            destination.Capacity = destinationViewModel.Capacity;
            destination.Status = destinationViewModel.Status;
            destination.Details1 = destinationViewModel.Details1;
            destination.Details2 = destinationViewModel.Details2;
            destination.Date = destinationViewModel.Date;
            _destinationService.TUpdate(destination);
            return RedirectToAction("Index", "Destination");
        }
    }
}