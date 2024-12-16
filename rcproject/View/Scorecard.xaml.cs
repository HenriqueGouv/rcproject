using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using rcproject.Model;
using rcproject.ViewModel;


namespace rcproject.View
{
    [QueryProperty(nameof(SelectedDriver), "SelectedDriver")]
    public partial class Scorecard : ContentPage
    {
        private Driver _selectedDriver;

        public Driver SelectedDriver
        {
            get => _selectedDriver;
            set
            {
                _selectedDriver = value;
                OnPropertyChanged();
            }
        }
        public Scorecard(Driver selectedDriver)
        {
            InitializeComponent();
            SetupButtonHandlers();
            
        }

        public Dictionary<string, int> penalties = new()
        {
            { "Gate", 0 },
            { "Boundary", 0 },
            { "Touch", 0 },
            { "Reposition", 0 },
            { "WrongGate", 0 },
            { "DNF", 0 },
            { "DNS", 0 }
        };

        public Dictionary<string, int> penaltyValues = new()
        {
            { "Gate", 10 },
            { "Boundary", 10 },
            { "Touch", 10 },
            { "Reposition", 20 },
            { "WrongGate", 10 },
            { "DNF", 20 },
            { "DNS", 200 }
        };

        

        

        public void SetupButtonHandlers()
        {
            var stackLayout = Content.FindByName<StackLayout>("ScoreEntries");
            foreach (Grid grid in stackLayout.Children.OfType<Grid>())
            {
                var frame = grid.Children.OfType<Frame>().FirstOrDefault();
                var label = frame?.Content as Label;
                var addButton = grid.Children.OfType<Button>().FirstOrDefault(b => b.Text == "+");
                var subtractButton = grid.Children.OfType<Button>().FirstOrDefault(b => b.Text == "-");

                if (label != null)
                {
                    string penaltyType = label.Text.Split('(')[0].Trim();

                    if (addButton != null)
                        addButton.Clicked += (s, e) => AddPenalty(penaltyType);

                    if (subtractButton != null)
                        subtractButton.Clicked += (s, e) => SubtractPenalty(penaltyType);
                }
            }
        }

        public void AddPenalty(string penaltyType)
        {
            penalties[penaltyType]++;
            UpdateScore();
        }

        public void SubtractPenalty(string penaltyType)
        {
            if (penalties[penaltyType] > 0)
            {
                penalties[penaltyType]--;
                UpdateScore();
            }
        }

        public void UpdateScore()
        {
            int totalScore = 0;
            foreach (var penalty in penalties)
            {
                totalScore += penalty.Value * penaltyValues[penalty.Key];
            }
            scoreLabel.Text = $"Total Score: {totalScore}";
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            if (_selectedDriver != null)
            {
                int finalScore = penalties.Sum(p => p.Value * penaltyValues[p.Key]);
                _selectedDriver.DriverScore += finalScore;

                await DisplayAlert("Score Submitted",
                    $"Final Score: {finalScore}\nUpdated Driver Score: {_selectedDriver.DriverScore}",
                    "OK");

                var viewModel = BindingContext as LeaderboardViewModel;
                if (viewModel != null)
                {
                    viewModel.LoadDrivers(viewModel.SelectedCompetition); // Refresh the driver list
                }
            }
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return true;
        }
    }
}