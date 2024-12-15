using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Maui.Devices.Sensors;


namespace rcproject.Services
{
    public class GeocodingService
    {
        private readonly string apiKey = "YOUR_GOOGLE_MAPS_API_KEY"; // Replace with your actual API key

        public async Task<Location> GetLocationFromAddressAsync(string address)
        {
            using var client = new HttpClient();
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={apiKey}";
            var response = await client.GetStringAsync(url);
            var json = JObject.Parse(response);

            var location = json["results"]?[0]?["geometry"]?["location"];
            if (location != null)
            {
                var latitude = location.Value<double>("lat");
                var longitude = location.Value<double>("lng");
                return new Location(latitude, longitude);
            }
            else
            {
                // Fallback location
                return new Location(0, 0);
            }
        }
    }
}
