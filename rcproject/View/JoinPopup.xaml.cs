using CommunityToolkit.Maui.Views;
using rcproject.ViewModel;
using rcproject.Model;

namespace rcproject.View;

public partial class JoinPopup : Popup
{
	public JoinPopup(Competition competition)
	{
		InitializeComponent();
		this.BindingContext = new JoinCompetition(competition, this);
	}

	public void ClosePopup()
	{
		Close();
	}
}