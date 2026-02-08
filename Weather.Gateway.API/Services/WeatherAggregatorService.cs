using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using Weather.Gateway.API.Configurations;
using Weather.Gateway.API.DTOs;

namespace Weather.Gateway.API.Services
{
    public class WeatherAggregatorService
    {
        private readonly HttpClient _httpClient;
        private readonly ServiceUrls _urls;

        public WeatherAggregatorService(HttpClient httpClient, IOptions<ServiceUrls> options)
        {
            _httpClient = httpClient;
            _urls = options.Value;
        }

        public async Task<WeatherByCityResponse?> GetWeatherByCityAsync(string city)
        {
            var geo = await _httpClient.GetFromJsonAsync<GeocodeResponseDto>(
                $"{_urls.GeocodingService}/api/geocode/{city}");

            if (geo == null)
                return null;

            var weather = await _httpClient.GetFromJsonAsync<WeatherResponseDto>(
                $"{_urls.WeatherService}/api/weather?lat={geo.latitude}&lon={geo.longitude}");

            if (weather == null)
                return null;

            return new WeatherByCityResponse
            {
                City = city,
                Latitude = geo.latitude,
                Longitude = geo.longitude,
                Temperature = weather.temperature,
                Windspeed = weather.windspeed
            };
        }
    }
}
