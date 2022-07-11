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
        public string _species = String.Empty;

        public PokemonDetailPageViewModel(IPokeApiService pokeApiService)
        {
            _pokeApiService = pokeApiService;
        }

        public async Task GetPokemonSpecies()
        {
            var species = await _pokeApiService.GetSpecies(Pokemon);

            species.EggGroups.ForEach(eg => Species = $"{Species}, {eg.Name.ToUpper()[0]}{eg.Name.Substring(1)}");

            if (Species.Length > 1)
                Species = Species.Remove(0, 2);
        }
    }
}
