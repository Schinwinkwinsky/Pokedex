using Pokedex.Maui.ViewModels;

namespace Pokedex.Maui.Views;

public partial class PokemonsPage : ContentPage
{
	private readonly PokemonsPageViewModel _viewModel;

	public PokemonsPage(PokemonsPageViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;
		BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
        try
        {
            await _viewModel.SetPokemons();
        }
        catch (Exception)
        {
            await DisplayAlert("Ops", "It was not possible to load pokemons. Scroll down to try again.", "OK");

            throw;
        }
    }
}