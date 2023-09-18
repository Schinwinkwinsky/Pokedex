using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Pokedex.Maui.Services;
using Pokedex.Maui.ViewModels;
using Pokedex.Maui.Views;

namespace Pokedex
{
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
            builder.UseMauiCommunityToolkit();

            // Services
            builder.Services.AddSingleton<IPokeApiService, PokeApiService>();

            // ViewModels
            builder.Services.AddSingletonWithShellRoute<PokemonsPage, PokemonsPageViewModel>("pokemons");
            builder.Services.AddTransientWithShellRoute<PokemonDetailPage, PokemonDetailPageViewModel>("details");

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}