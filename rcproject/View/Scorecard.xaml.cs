using Microsoft.Maui.Controls;

namespace rcproject.View
{
    public partial class Scorecard : ContentPage
    {
        private Dictionary<string, int> penalties = new()
        {
            { "Gate", 0 },
            { "Boundary", 0 },
            { "Touch", 0 },
            { "Reposition", 0 },
            { "WrongGate", 0 },
            { "DNF", 0 },
            { "DNS", 0 }
        };

        private Dictionary<string, int> penaltyValues = new()
        {
            { "Gate", 10 },
            { "Boundary", 10 },
            { "Touch", 10 },
            { "Reposition", 20 },
            { "WrongGate", 10 },
            { "DNF", 20 },
            { "DNS", 200 }
        };

        public Scorecard()
        {
            InitializeComponent();
            SetupButtonHandlers();
        }

        private void SetupButtonHandlers()
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

        private void AddPenalty(string penaltyType)
        {
            penalties[penaltyType]++;
            UpdateScore();
        }

        private void SubtractPenalty(string penaltyType)
        {
            if (penalties[penaltyType] > 0)
            {
                penalties[penaltyType]--;
                UpdateScore();
            }
        }

        private void UpdateScore()
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
            int finalScore = penalties.Sum(p => p.Value * penaltyValues[p.Key]);

            await DisplayAlert("Score Submitted",
                              $"Final Score: {finalScore}\nPenalties:\n" +
                              string.Join("\n", penalties.Select(p => $"{p.Key}: {p.Value}")),
                              "OK");

            // Reset penalties
            foreach (var key in penalties.Keys.ToList())
            {
                penalties[key] = 0;
            }
            UpdateScore();

            // Pop current page and navigate to existing Leaderboard
            await Navigation.PopAsync();
            await Shell.Current.GoToAsync("//Drivers");
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return true;
        }
    }
}