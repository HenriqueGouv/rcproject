namespace rcproject.View;

public partial class Competitions : ContentPage
{
    public Competitions()
    {
        InitializeComponent();
    }

    private async void OnCard1Tapped(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Competition",
            "Enter competition code:",
            "Submit",
            "Cancel",
            "Enter code here",
            maxLength: 10,
            keyboard: Keyboard.Text);

        if (!string.IsNullOrEmpty(result))
        {
            // Handle the code input here
            await DisplayAlert("Success", "Code submitted: " + result, "OK");
        }
    }

    private async void OnCard2Tapped(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Competition",
            "Enter competition code:",
            "Submit",
            "Cancel",
            "Enter code here",
            maxLength: 10,
            keyboard: Keyboard.Text);

        if (!string.IsNullOrEmpty(result))
        {
            // Handle the code input here
            await DisplayAlert("Success", "Code submitted: " + result, "OK");
        }
    }

    private async void OnCard3Tapped(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Competition",
            "Enter competition code:",
            "Submit",
            "Cancel",
            "Enter code here",
            maxLength: 10,
            keyboard: Keyboard.Text);

        if (!string.IsNullOrEmpty(result))
        {
            // Handle the code input here
            await DisplayAlert("Success", "Code submitted: " + result, "OK");
        }
    }
    private async void OnCreateCompetitionClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateCompetition());
    }
}