using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rcproject.Model
{

    public class Competition
    {  
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public TimeSpan Time { get; set; } = TimeSpan.Zero;
        public string JoinCode { get; set; } = string.Empty;
        public string MapsImageUrl => $"https://maps.googleapis.com/maps/api/staticmap?center={Uri.EscapeDataString(Location)}&zoom=15&size=600x300&maptype=roadmap&key=YOUR_GOOGLE_MAPS_API_KEY";
    }

}
