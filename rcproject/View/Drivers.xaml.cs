using rcproject.Model;
using rcproject.ViewModel;

namespace rcproject.View;

public partial class Drivers : ContentPage
{
	public Drivers(Competition selectedCompetition)
	{
		InitializeComponent();
        BindingContext = new LeaderboardViewModel(selectedCompetition);
    }
    public Drivers()
    {
        InitializeComponent();
        BindingContext = new LeaderboardViewModel();
    }
}