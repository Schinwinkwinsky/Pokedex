using Pokedex.Maui.ViewModels;

namespace Pokedex.Maui.Views;

public partial class PokemonDetailPage : ContentPage
{
	private PokemonDetailPageViewModel _viewModel;

	public PokemonDetailPage(PokemonDetailPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

		_viewModel = viewModel;
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		await _viewModel.GetPokemonTypes();
	}
}