namespace rcproject.View;

public partial class Competitions : ContentPage
{
    public Competitions()
    {
        InitializeComponent();
        BindingContext = new Competitions();
    }
    private async void OnCreateCompetitionClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateCompetitions());
    }
}