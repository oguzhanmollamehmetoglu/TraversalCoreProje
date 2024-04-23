using BusinessLayer.Abstract;
using DTOLayer.DTOs.FeatureDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IFeature2Service _feature2Service;

        public FeatureController(IFeatureService featureService, IFeature2Service feature2Service)
        {
            _featureService = featureService;
            _feature2Service = feature2Service;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _featureService.TGetListByFeatureAndFeature2();
            return View(values);
        }

        [HttpGet]
        [Route("EditFeature/{id}")]
        public IActionResult EditFeature(int id)
        {
            var values = _featureService.TGetByID(id);
            FeatureViewDTO featureViewModel = new FeatureViewDTO();
            featureViewModel.FeatureID = values.FeatureID;
            featureViewModel.Title = values.Title;
            featureViewModel.Description = values.Description;
            featureViewModel.Image = values.Image;
            return View(featureViewModel);
        }

        [HttpPost]
        [Route("EditFeature/{id}")]
        public async Task<IActionResult> EditFeature(FeatureViewDTO featureViewModel, Feature feature)
        {
            if (featureViewModel.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(featureViewModel.ImageFile.FileName);
                var imagename = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                featureViewModel.Image = imagename;
                feature.Image = featureViewModel.Image;
                await featureViewModel.ImageFile.CopyToAsync(stream);
            }
            feature.FeatureID = featureViewModel.FeatureID;
            feature.Title = featureViewModel.Title;
            feature.Description = featureViewModel.Description;
            feature.Status = true;
            _featureService.TUpdate(feature);
            return RedirectToAction("Index", "Feature");
        }

        [HttpGet]
        [Route("EditFeature2/{id}")]
        public IActionResult EditFeature2(int id)
        {
            var values = _feature2Service.TGetByID(id);
            Feature2ViewDTO feature2ViewModel = new Feature2ViewDTO();
            feature2ViewModel.Feature2ID = values.Feature2ID;
            feature2ViewModel.Title = values.Title;
            feature2ViewModel.Description = values.Description;
            feature2ViewModel.Image = values.Image;
            return View(feature2ViewModel);
        }

        [HttpPost]
        [Route("EditFeature2/{id}")]
        public async Task<IActionResult> EditFeature2(Feature2ViewDTO feature2ViewModel, Feature2 feature2)
        {
            if (feature2ViewModel.ImageFile2 != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(feature2ViewModel.ImageFile2.FileName);
                var imagename = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                feature2ViewModel.Image = imagename;
                feature2.Image = feature2ViewModel.Image;
                await feature2ViewModel.ImageFile2.CopyToAsync(stream);
            }
            feature2.Feature2ID = feature2ViewModel.Feature2ID;
            feature2.Title = feature2ViewModel.Title;
            feature2.Description = feature2ViewModel.Description;
            feature2.Status = true;
            _feature2Service.TUpdate(feature2);
            return RedirectToAction("Index", "Feature");
        }
    }
}