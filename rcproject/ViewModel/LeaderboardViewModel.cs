using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using rcproject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rcproject.ViewModel
{
    [QueryProperty(nameof(SelectedCompetition), "Competition")]
    public partial class LeaderboardViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task NavigateToScorecard(Driver driver)
        {
            var navigationParameters = new Dictionary<string, object>
            {
                { "SelectedDriver", driver }
            };
            await Shell.Current.GoToAsync("///Scorecard", navigationParameters);
        }



        private Competition selectedCompetition;

        public Competition SelectedCompetition
        {
            get => selectedCompetition;
            set
            {
                SetProperty(ref selectedCompetition, value);
                LoadDrivers(selectedCompetition);

            }
        }
        public LeaderboardViewModel()
        {

        }
        public LeaderboardViewModel(Competition selectedCompetition)
        {
            selectedCompetition = selectedCompetition;
            LoadDrivers(selectedCompetition);
        }


     
        [ObservableProperty]
        private ObservableCollection<Driver> drivers;
     

        public void LoadDrivers(Competition competition)
        {
            if (competition == null || competition.Drivers == null)
            {
                drivers = new ObservableCollection<Driver>();
                Debug.WriteLine("Drivers collection initialized as empty");
            }
            else
            {
              
                var sortedDrivers = competition.Drivers.OrderBy(d => d.DriverScore).ToList();

         
                for (int i = 0; i < sortedDrivers.Count; i++)
                {
                    sortedDrivers[i].Position = i + 1;
                    Debug.WriteLine($"Driver: {sortedDrivers[i].DriverName}, Position: {sortedDrivers[i].Position}, Score: {sortedDrivers[i].DriverScore}");

                }

                drivers = new ObservableCollection<Driver>(sortedDrivers);
                Debug.WriteLine("Drivers collection loaded and sorted");
            }
        }

    }
}
