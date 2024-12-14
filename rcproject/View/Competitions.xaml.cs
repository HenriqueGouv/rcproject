using Microsoft.Maui.Controls.Maps;
using rcproject.Services;

namespace rcproject.View;

public partial class Competitions : ContentPage
{
   
    public Competitions()
	{
		InitializeComponent();
		BindingContext = App.ViewModel; 
		
	
    }
}