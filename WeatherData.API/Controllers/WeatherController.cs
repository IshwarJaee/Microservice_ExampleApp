using Microsoft.AspNetCore.Mvc;
using WeatherData.API.Services;

namespace WeatherData.API.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _service;

        public WeatherController(WeatherService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeather(double lat, double lon)
        {
            var weather = await _service.GetWeatherAsync(lat, lon);

            if (weather == null)
                return NotFound("Weather data not found");

            return Ok(weather);
        }
    }
}
