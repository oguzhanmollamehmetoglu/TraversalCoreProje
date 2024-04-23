using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/Destination")]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());

        [Route("GetCitiesSearchByName")]
        public IActionResult GetCitiesSearchByName(string searchstring)
        {
            ViewData["CurrentFilter"] = searchstring;
            var values = from x in destinationManager.TGetList() select x;
            if (!string.IsNullOrEmpty(searchstring))
            {
                values = values.Where(y => y.City.Contains(searchstring));
            }
            return View(values.ToList());
        }
    }
}