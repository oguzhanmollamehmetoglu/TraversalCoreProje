using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ApiExchange")]
    public class ApiExchangeController : Controller
    {
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            List<BookingExchangeViewModel2> list = new List<BookingExchangeViewModel2>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
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
                var value = JsonConvert.DeserializeObject<BookingExchangeViewModel>(body);
                return View(value.exchange_rate_buy);
            }
        }
    }
}