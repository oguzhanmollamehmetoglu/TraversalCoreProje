using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/City")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("CityList")]
        public IActionResult CityList()
        {
            var jsoncity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsoncity);
        }

        [Route("AddCityDestination")]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TInsert(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        [Route("GetById/{DestinationID}")]
        public IActionResult GetById(int DestinationID)
        {
            var values = _destinationService.TGetByID(DestinationID);
            var jsonvalues = JsonConvert.SerializeObject(values);
            return Json(jsonvalues);
        }

        [Route("DeleteCity/{id}")]
        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return NoContent();
        }

        [Route("UpdateCity")]
        public IActionResult UpdateCity(Destination destination)
        {
            _destinationService.TUpdate(destination);
            var values2 = JsonConvert.SerializeObject(destination);
            return Json(values2);
        }

        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass
        //    {
        //        CityId = 1,
        //        CityName = "Trabzon",
        //        CityCountry = "Türkiye"
        //    },
        //    new CityClass
        //    {
        //        CityId = 2,
        //        CityName = "Antalya",
        //        CityCountry = "Türkiye"
        //    },
        //    new CityClass
        //    {
        //        CityId = 3,
        //        CityName = "İstanbul",
        //        CityCountry = "Türkiye"
        //    }

        //}; 
    }
}