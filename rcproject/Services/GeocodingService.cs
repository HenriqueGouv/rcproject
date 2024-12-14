using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rcproject.Services
{
    public class GeocodingService
    {
        private readonly string apiKey = "AIzaSyBHFRvlRcO5RLg4CgYOpK1VOzCponiPcaA";

        public async Task<Location> GetLocationFromAddressAsync(string address)
        {
            using var client = new HttpClient();
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key={apiKey}";
            var response = await client.GetStringAsync(url);
            var json = JObject.Parse(response);

            var location = json["results"]?[0]?["geometry"]?["location"];
            if (location != null)
            {
                var latitude = location.Value<double>("lat");
                var longitude = location.Value<double>("lng");
                return new Location(latitude, longitude);
            }

            return new Location(0, 0);
        }
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
