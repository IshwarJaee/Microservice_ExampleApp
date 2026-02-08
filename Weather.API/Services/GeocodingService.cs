using System.Net.Http.Json;
using Weather.API.DTOs;

namespace Weather.API.Services
{
    public class GeocodingService
    {
        private readonly HttpClient _httpClient;
        public GeocodingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GeocodingResult> GetCoordinatesAsync(string city)
        {
            var response = await _httpClient.GetFromJsonAsync<GeocodingResponse>(
                $"https://geocoding-api.open-meteo.com/v1/search?name={city}");

            return response?.results?.FirstOrDefault();
        }
    }
}
