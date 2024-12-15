using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
using rcproject.Services;
using rcproject.ViewModel;

namespace rcproject.View;

public partial class Competitions : ContentPage
{
    private readonly GeocodingService geocodingService = new GeocodingService();
    public CreateCompetitions ViewModel { get; set; }

    public Competitions()
	{
		InitializeComponent();
        ViewModel = new CreateCompetitions();
		BindingContext = ViewModel; 
		
	
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        foreach (var competition in ViewModel.Competitions)
        {
            var location = await geocodingService.GetLocationFromAddressAsync(competition.Location);
            MyMap.Pins.Add(new Pin
            {
                Label = competition.Name,
                Location = location ?? new Location(0, 0) // Fallback location
            });
        }
    }
}