using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rcproject.Model
{

    public class Competition
    {  
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string JoinCode { get; set; }
        public string MapsImageUrl => $"https://maps.googleapis.com/maps/api/staticmap?center={Uri.EscapeDataString(Location)}&zoom=15&size=600x300&maptype=roadmap&key=YOUR_GOOGLE_MAPS_API_KEY";
    }

}
