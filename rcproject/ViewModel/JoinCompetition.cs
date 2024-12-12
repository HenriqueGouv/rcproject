using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using rcproject.Model;
using rcproject.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rcproject.ViewModel
{
    [QueryProperty(nameof(Competition), "Competition")]
    public partial class JoinCompetition:ObservableObject
    {
        private readonly JoinPopup popup;
        public JoinCompetition(Competition competition, JoinPopup popup)
        {
            Competition = competition;
            this.popup = popup;
            HasError = false;
        }

        [ObservableProperty]
        private Competition competition;

        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private string joinCode;

        [ObservableProperty]
        private string errorMessage;

        [ObservableProperty]
        private bool hasError;

        [RelayCommand]
        private async Task Join()
        {
            Debug.WriteLine("Join command executed");
            Debug.WriteLine($"JoinCode: {JoinCode}, Competition JoinCode: {Competition.JoinCode}");

            if (JoinCode == Competition.JoinCode)
            {
                if (Competition.Drivers == null)
                {
                    Competition.Drivers = new ObservableCollection<Driver>();
                    Debug.WriteLine("Initialized Competition.Drivers collection");
                }
                

                Competition.Drivers.Add(new Driver { DriverName = UserName, DriverScore = 0 });

                Debug.WriteLine($"Driver added: {UserName}");

                popup.ClosePopup();

                await Shell.Current.GoToAsync("///CompetitionDetailPage", new Dictionary<string, object>
                {
                    { "Competition", Competition }
                });

             
            }
            else
            {
                ErrorMessage = "Invalid join code. Please try again.";
                HasError = true;
                Debug.WriteLine(ErrorMessage);
            }
        }
    }

}

