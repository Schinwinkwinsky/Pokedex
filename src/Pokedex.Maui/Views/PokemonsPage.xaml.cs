using Pokedex.Maui.ViewModels;

namespace Pokedex.Maui.Views;

public partial class PokemonsPage : ContentPage
{
	public PokemonsPage()
	{
		InitializeComponent();
		BindingContext = new PokemonsPageViewModel();
	}
}