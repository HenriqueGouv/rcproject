namespace rcproject.View
{
    public partial class CreateCompetition : ContentPage
    {
        public CreateCompetition()
        {
            InitializeComponent();
        }

        private async void OnCreateClicked(object sender, EventArgs e)
        {
            // Handle the creation of new competition
            string name = CompetitionName.Text;
            string location = Location.Text;
            DateTime date = CompetitionDate.Date;
            TimeSpan time = CompetitionTime.Time;

            // Add your logic to create the competition
            await DisplayAlert("Success", "Competition Created!", "OK");
            await Navigation.PopAsync();
        }
    }
}