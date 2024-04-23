using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/BookingHotelSearch")]
    public class BookingHotelSearchController : Controller
    {
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?room_number=1&adults_number=2&checkout_date=2024-05-20&filter_by_currency=EUR&units=metric&locale=en-gb&checkin_date=2024-05-19&dest_type=city&dest_id=-1456928&order_by=popularity&children_ages=5%2C0&children_number=2&include_adjacency=true&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&page_number=0"),
                Headers =
                {
                   { "X-RapidAPI-Key", "1afb4b1a22mshf82c14a89778f0ap176907jsnc0ab3d4d7430" },
                   { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bodyreplace = body.Replace(".", "");
                var value = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(bodyreplace);
                return View(value.results);
            }
        }

        [HttpGet]
        [Route("GetCityDestID")]
        public IActionResult GetCityDestID()
        {
            return View();
        }

        [HttpPost]
        [Route("GetCityDestID/{id}")]
        public async Task<IActionResult> GetCityDestID(string p)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={p}"),
                Headers =
                {
                   { "X-RapidAPI-Key", "1afb4b1a22mshf82c14a89778f0ap176907jsnc0ab3d4d7430" },
                   { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return View();
            }
        }

    }
}