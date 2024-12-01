using rcproject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rcproject.ViewModel
{
    public class CreateCompetitions : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Competition> Competitions { get; set; }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string location;
        public string Location
        {
            get => location;
            set
            {
                if (location != value)
                {
                    location = value;
                    OnPropertyChanged(nameof(Location));
                    MapsImageUrl = GenerateMapsImageUrl(location);
                }
            }
        }

        private DateTime date = DateTime.Now;
        public DateTime Date
        {
            get => date;
            set
            {
                if (date != value)
                {
                    date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        private TimeSpan time = DateTime.Now.TimeOfDay;
        public TimeSpan Time
        {
            get => time;
            set
            {
                if (time != value)
                {
                    time = value;
                    OnPropertyChanged(nameof(Time));
                }
            }
        }

        private string joinCode;
        public string JoinCode
        {
            get => joinCode;
            set
            {
                if (joinCode != value)
                {
                    joinCode = value;
                    OnPropertyChanged(nameof(JoinCode));
                }
            }
        }

        private string mapsImageUrl;
        public string MapsImageUrl
        {
            get => mapsImageUrl;
            set
            {
                if (mapsImageUrl != value)
                {
                    mapsImageUrl = value;
                    OnPropertyChanged(nameof(MapsImageUrl));
                }
            }
        }

        public Command CreateCompetitionCommand { get; }

        public CreateCompetitions()
        {
            Competitions = new ObservableCollection<Competition>();
            CreateCompetitionCommand = new Command(OnCreateCompetition);
        }

        private void OnCreateCompetition()
        {
            var competition = new Competition
            {
                Name = Name,
                Location = Location,
                Date = Date,
                Time = Time,
                JoinCode = JoinCode
            };

            Competitions.Add(competition);

            // Clear input fields
            Name = string.Empty;
            Location = string.Empty;
            Date = DateTime.Now;
            Time = DateTime.Now.TimeOfDay;
            JoinCode = string.Empty;
            MapsImageUrl = null;
        }

        private string GenerateMapsImageUrl(string location)
        {
            var apiKey = "YOUR_GOOGLE_MAPS_API_KEY";
            var baseUrl = "https://maps.googleapis.com/maps/api/staticmap";
            var url = $"{baseUrl}?center={Uri.EscapeDataString(location)}&zoom=15&size=600x300&maptype=roadmap&key={apiKey}";
            return url;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
