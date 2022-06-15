using CommunityToolkit.Maui;
using Pokedex.Maui.Services;
using Pokedex.Maui.ViewModels;
using Pokedex.Maui.Views;

namespace Pokedex.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Lobster-Regular.ttf", "LobsterRegular");
			});

        // Initialize MauiToolkit
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

        // Services
        builder.Services.AddSingleton<IPokeApiService, PokeApiService>();		

		// ViewModels
		builder.Services.AddSingleton<PokemonsPageViewModel>();

        // Views
        builder.Services.AddSingleton<PokemonsPage>();

        return builder.Build();
	}
}
