using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.API.Services;

namespace Weather.API.Controllers
{
    [Route("api/geocode")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly GeocodingService _service;

        public WeatherController(GeocodingService service)
        {
            _service = service;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetCorrdinates(string city)
        {
            var results = await _service.GetCoordinatesAsync(city);

            if (results == null) { return NotFound("City not found"); }
            return Ok(results);
        }
    }
}
