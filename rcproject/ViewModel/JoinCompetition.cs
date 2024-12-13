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
    [QueryProperty(nameof(SelectedCompetition), "Competition")]
    public partial class JoinCompetition : ObservableObject
    {
        private readonly JoinPopup popup;

        private Competition selectedCompetition;

        public Competition SelectedCompetition
        {
            get => selectedCompetition;
            set
            {
                SetProperty(ref selectedCompetition, value);

            }
        }
        public JoinCompetition(Competition competition, JoinPopup popup)
        {
            selectedCompetition = competition;
            this.popup = popup;
            HasError = false;
        }

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
            Debug.WriteLine($"JoinCode: {JoinCode}, Competition JoinCode: {selectedCompetition.JoinCode}");
            Debug.WriteLine($"UserName: {UserName}");

            if (!string.IsNullOrWhiteSpace(JoinCode) && JoinCode == selectedCompetition.JoinCode)
            {
                if (selectedCompetition.Drivers == null)
                {
                    selectedCompetition.Drivers = new ObservableCollection<Driver>();
                    Debug.WriteLine("Initialized SelectedCompetition.Drivers collection");
                }

                SelectedCompetition.Drivers.Add(new Driver { DriverName = UserName, DriverScore = 0 });
                Debug.WriteLine($"Driver added: {UserName}");

                popup.ClosePopup();

                await Shell.Current.GoToAsync("///CompetitionDetailPage", new Dictionary<string, object>
                {
                    { "Competition", selectedCompetition }
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

