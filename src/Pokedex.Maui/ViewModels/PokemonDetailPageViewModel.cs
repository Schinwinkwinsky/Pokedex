using CommunityToolkit.Mvvm.ComponentModel;
using PokeApiNet;
using Pokedex.Maui.Services;

namespace Pokedex.Maui.ViewModels
{
    [QueryProperty("Pokemon", "Pokemon")]
    public partial class PokemonDetailPageViewModel : BaseViewModel
    {
        private readonly IPokeApiService _pokeApiService;
        
        [ObservableProperty]
        private Pokemon _pokemon;

        [ObservableProperty]
        public string _types = String.Empty;

        public PokemonDetailPageViewModel(IPokeApiService pokeApiService)
        {
            _pokeApiService = pokeApiService;
        }

        public async Task GetPokemonTypes()
        {
            var types = await _pokeApiService.GetPokemonTypes(Pokemon);

            types.ToList().ForEach(t => Types = $"{Types}, {t.Name.ToUpper()[0]}{t.Name.Substring(1)}");

            if (Types.Length > 1)
                Types = Types.Remove(0, 2);
        }
    }
}
