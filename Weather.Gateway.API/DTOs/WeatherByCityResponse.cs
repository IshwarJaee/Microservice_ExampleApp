namespace Weather.Gateway.API.DTOs
{
    public class WeatherByCityResponse
    {
        public string City { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Temperature { get; set; }
        public double Windspeed { get; set; }

    }
}
