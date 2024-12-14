
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Maps;
using rcproject.Services;
using Location = rcproject.Services.Location;

namespace rcproject.Converters
{
    namespace rcproject.Converters
    {
        public class AddressToLocationConverter : IValueConverter
        {
            private readonly GeocodingService geocodingService = new GeocodingService();

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var address = value as string;
                if (!string.IsNullOrEmpty(address))
                {
                    // Asynchronous conversion
                    var locationTask = Task.Run(async () => await geocodingService.GetLocationFromAddressAsync(address));
                    locationTask.Wait();

                    return locationTask.Result;
                }
                return new Location(0, 0);
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
