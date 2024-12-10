namespace rcproject.View;

public partial class CreateCompetition : ContentPage
{
	public CreateCompetition()
	{
		InitializeComponent();
		BindingContext = App.ViewModel;
	}
}