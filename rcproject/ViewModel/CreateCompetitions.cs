using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Devices.Sensors;
using rcproject.Model;
using rcproject.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Competition = rcproject.Model.Competition;

namespace rcproject.ViewModel
{
    public partial class CreateCompetitions : ObservableObject
    {
       
        [ObservableProperty]
        string name;

        [ObservableProperty]
        string location;

        [ObservableProperty]
        DateTime date;

        [ObservableProperty]    
        TimeSpan time;

        [ObservableProperty]
        string joinCode;

       

        public ObservableCollection<Competition> Competitions { get; set; }

        public CreateCompetitions()
        {
            Competitions = new ObservableCollection<Competition>();

            Date = DateTime.Now;
            Time = DateTime.Now.TimeOfDay;
           
        
        }

        [RelayCommand]
        private void AddCompetition()
        {
            var newCompetition = new Competition
            {
                Name = Name,
                Location = Location,
                Date = Date,
                Time = Time,
                JoinCode = JoinCode
            };

            Competitions.Add(newCompetition);
           
        }

        [RelayCommand]
        private void RemoveCompetition(Competition competition)
        {
            if (Competitions.Contains(competition))
            {
                Competitions.Remove(competition);
            }
        }

        [RelayCommand]
        private async Task NavigateToCreateCompetition()
        {
            await Shell.Current.GoToAsync("///CreateCompetition");
        }

        [RelayCommand]
        private async Task NavigateToCompetitionDetail(Competition competition)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                {"Competition", competition }
            };
            await Shell.Current.GoToAsync("///CompetitionDetailPage", navigationParameter);
        }

    }
}
