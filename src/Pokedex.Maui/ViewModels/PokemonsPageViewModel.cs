using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokeApiNet;
using Pokedex.Maui.Services;
using System.Collections.ObjectModel;

namespace Pokedex.Maui.ViewModels
{
    public partial class PokemonsPageViewModel : BaseViewModel
    {
        private readonly IPokeApiService _pokeApiService;

        private int _defaultLimit = 30;

        [ObservableProperty]
        private bool _isRefreshing;

        public ObservableCollection<Pokemon> Pokemons { get; private set; } = new();

        public PokemonsPageViewModel(IPokeApiService pokeApiService)
        {
            Title = "Pokemons";

            _pokeApiService = pokeApiService;
        }

        [ICommand]
        public async Task InitializePokemons()
        {
            try
            {
                IsBusy = true;

                await PullPokemons(_defaultLimit, true);
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Ops", "It was not possible to load pókemons. Pull to refresh.", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [ICommand]
        public async Task RefreshPokemons()
        {
            try
            {
                IsRefreshing = true;

                await PullPokemons(_defaultLimit, true);
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Ops", "It was not possible to load pókemons. Pull to refresh.", "OK");
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        [ICommand]
        public async Task GetPokemons()
        {
            try
            {
                IsBusy = true;

                await PullPokemons(_defaultLimit);

            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Ops", "It was not possible to load pókemons. Pull to refresh.", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task PullPokemons(int limit, bool clearPokemonsList = false)
        {
            if (clearPokemonsList && Pokemons.Any())
                Pokemons.Clear();

            var offset = Pokemons.Count();

            var pokemons = await _pokeApiService.GetPokemons(limit, offset);

            pokemons.ToList().ForEach(p => Pokemons.Add(p));
        }
    }
}
