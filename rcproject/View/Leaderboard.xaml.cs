using rcproject.Model;
using rcproject.ViewModel;

namespace rcproject.View;

public partial class Leaderboard : ContentPage
{
    public Leaderboard(Competition selectedCompetition)
    {
        InitializeComponent();
        BindingContext = new LeaderboardViewModel(selectedCompetition);
    }
    public Leaderboard()
	{
		InitializeComponent();
        BindingContext = new LeaderboardViewModel();
	}
}