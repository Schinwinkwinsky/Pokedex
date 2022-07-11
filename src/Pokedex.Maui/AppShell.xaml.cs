using Pokedex.Maui.Views;

namespace Pokedex.Maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(PokemonDetailPage), typeof(PokemonDetailPage));
    }
}
