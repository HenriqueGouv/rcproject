using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using rcproject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rcproject.ViewModel
{
    [QueryProperty(nameof(SelectedCompetition), "Competition")]
    public partial class CompetitionDetailViewModel : ObservableObject
    {
        private Competition selectedCompetition;

        public Competition SelectedCompetition
        {
            get => selectedCompetition;
            set
            {
                SetProperty(ref selectedCompetition, value);
              
            }
        }

        public string Name => SelectedCompetition?.Name;
        public DateTime Date => SelectedCompetition?.Date ?? DateTime.Now;
        public TimeSpan Time => SelectedCompetition?.Time ?? TimeSpan.Zero;
        public string Location => SelectedCompetition?.Location;



        [RelayCommand]
        private async Task NavigateToDrivers()
        {
            await Shell.Current.GoToAsync("///Drivers");
        }

        [RelayCommand]
        private async Task NavigateToScorecard()
        {
            await Shell.Current.GoToAsync("///Scorecard");
        }

        [RelayCommand]
        private async Task NavigateToRuleset()
        {
            await Shell.Current.GoToAsync("///Ruleset");
        }

        [RelayCommand]
        private async Task NavigateToLeaderboard()
        {
            var navigationParameters = new Dictionary<string, object>
            {
                { "Competition", SelectedCompetition }
            };
            await Shell.Current.GoToAsync("///Leaderboard", navigationParameters);
        }


        [RelayCommand]
        private void ShowJoinPopup()
        {

            var joinPopup = new rcproject.View.JoinPopup(SelectedCompetition);
            Application.Current.MainPage.ShowPopup(joinPopup);

        }


    }
}
