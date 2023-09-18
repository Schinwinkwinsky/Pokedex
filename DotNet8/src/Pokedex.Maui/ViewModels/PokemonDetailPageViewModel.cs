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
        public string _abilities = String.Empty;

        [ObservableProperty]
        public string _moves = String.Empty;

        [ObservableProperty]
        public string _types = String.Empty;

        public PokemonDetailPageViewModel(IPokeApiService pokeApiService)
        {
            _pokeApiService = pokeApiService;
        }

        public async Task InitializePokemonAsync()
        {
            IsBusy = true;

            await GetPokemonAbilitiesAsync();
            await GetPokemonMovesAsync();
            await GetPokemonTypesAsync();

            IsBusy = false;
        }


        private async Task GetPokemonAbilitiesAsync()
        {
            var abilites = await _pokeApiService.GetPokemonAbilitiesAsync(Pokemon);

            abilites.ToList().ForEach(a => Abilities = $"{Abilities}, {a.Name.ToUpper()[0]}{a.Name.Substring(1)}");

            if (Abilities.Length > 1)
                Abilities = Abilities.Remove(0, 2);
        }

        private async Task GetPokemonMovesAsync()
        {
            var moves = await _pokeApiService.GetPokemonMovesAsync(Pokemon);

            moves.ToList().ForEach(m => Moves = $"{Moves}, {m.Name.ToUpper()[0]}{m.Name.Substring(1)}");

            if (Moves.Length > 1)
                Moves = Moves.Remove(0, 2);
        }

        private async Task GetPokemonTypesAsync()
        {
            var types = await _pokeApiService.GetPokemonTypesAsync(Pokemon);

            types.ToList().ForEach(t => Types = $"{Types}, {t.Name.ToUpper()[0]}{t.Name.Substring(1)}");

            if (Types.Length > 1)
                Types = Types.Remove(0, 2);
        }
    }
}
