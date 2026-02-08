using WeatherData.API.DTOs;

namespace WeatherData.API.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CurrentWeather?> GetWeatherAsync(double lat, double lon)
        {
            var response = await _httpClient.GetFromJsonAsync<WeatherResponse>(
                $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true");

            return response?.current_weather;
        }
    }
}

