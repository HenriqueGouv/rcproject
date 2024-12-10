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
      
    }
}
