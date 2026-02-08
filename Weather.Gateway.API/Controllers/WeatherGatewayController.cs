using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Gateway.API.Services;

namespace Weather.Gateway.API.Controllers
{
    [Route("api/weather-by-city")]
    [ApiController]
    public class WeatherGatewayController : ControllerBase
    {
        private readonly WeatherAggregatorService _weatherAggregatorService;

        public WeatherGatewayController(WeatherAggregatorService weatherAggregatorService)
        {
            _weatherAggregatorService = weatherAggregatorService;
        }
        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            var weather = await _weatherAggregatorService.GetWeatherByCityAsync(city);

            if (weather == null) { return NotFound("City not found"); }

            return Ok(weather);
        }
    }
}
