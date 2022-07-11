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

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
		await _viewModel.InitializePokemons();
    }
}