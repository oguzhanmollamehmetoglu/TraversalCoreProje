using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DTOLayer.DTOs.DestinationsDTOs;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class ExelController : Controller
    {
        private readonly IExelService _exelService;

        public ExelController(IExelService exelService)
        {
            _exelService = exelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticExelReport()
        {
            return File(_exelService.ExelList(DestinationList()), "application/vdn.openxmlformats-officedocumet.spreadsheetml.sheet", "YeniExel.xlsx");
        }

        public List<DestinationModelDTO> DestinationList()
        {
            List<DestinationModelDTO> destinationModels = new List<DestinationModelDTO>();
            using (var c = new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModelDTO
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity
                }).ToList();
            }
            return destinationModels;
        }

        public IActionResult DestinationExelReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowcount = 2;
                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowcount, 1).Value = item.City;
                    workSheet.Cell(rowcount, 2).Value = item.DayNight;
                    workSheet.Cell(rowcount, 3).Value = item.Price;
                    workSheet.Cell(rowcount, 4).Value = item.Capacity;
                    rowcount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vdn.openxmlformats-officedocumet.spreadsheetml.sheet", "YeniListe.xlsx");
                }
            }
        }
    }
}