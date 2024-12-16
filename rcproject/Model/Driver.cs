using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace rcproject.Model
{
    public class Driver : ObservableObject
    {
        private int driverScore;
        public string DriverName { get; set; } = string.Empty;
        public int DriverScore
        {
            get => driverScore;
            set => SetProperty(ref driverScore, value); // This ensures property change notification
        }


        public int Position { get; set; } = 0;
    }
}
