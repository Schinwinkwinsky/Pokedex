using PokeApiNet;
using Pokedex.Maui.Services;
using System.Collections.ObjectModel;

namespace Pokedex.Maui.ViewModels
{
    public partial class PokemonsPageViewModel : BaseViewModel
    {
        private readonly IPokeApiService _pokeApiService;

        public ObservableCollection<Pokemon> Pokemons { get; private set; } = new();

        public PokemonsPageViewModel(IPokeApiService pokeApiService)
        {
            Title = "Pokemons";

            _pokeApiService = pokeApiService;
        }

        public async Task SetPokemons()
        {
            IsBusy = true;

            var pokemons = await _pokeApiService.GetPokemons(20, 0);

            if (Pokemons.Any())
                Pokemons.Clear();

            pokemons.ToList().ForEach(p => Pokemons.Add(p));

            IsBusy = false;
        }

        public async Task GetPokemons(int limit = 20)
        {
            IsBusy = true;

            var offset = Pokemons.Count();

            var pokemons = await _pokeApiService.GetPokemons(limit, offset);

            pokemons.ToList().ForEach(p => Pokemons.Add(p));


            IsBusy = false;
        }
    }
}
