using Microsoft.AspNetCore.Mvc;
using Weather.Gateway.API.Services;

namespace Weather.Gateway.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherAggregatorService _service;

        public HomeController(WeatherAggregatorService service)
        {
            this._service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string city)
        {
            var result = await _service.GetWeatherByCityAsync(city);

            if (result == null) { ViewBag.Error = "City nott found"; return View(); }

            return View(result);
        }
    }
}
