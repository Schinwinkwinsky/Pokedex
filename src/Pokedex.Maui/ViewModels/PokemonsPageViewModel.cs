using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokeApiNet;
using Pokedex.Maui.Services;
using Pokedex.Maui.Views;
using System.Collections.ObjectModel;

namespace Pokedex.Maui.ViewModels
{
    public partial class PokemonsPageViewModel : BaseViewModel
    {
        private readonly IPokeApiService _pokeApiService;

        private int _defaultLimit = 20;

        [ObservableProperty]
        private Pokemon _selectedPokemon;

        [ObservableProperty]
        private bool _isRefreshing;

        public ObservableCollection<Pokemon> Pokemons { get; } = new();

        public PokemonsPageViewModel(IPokeApiService pokeApiService)
        {
            Title = "Pokemons";

            _pokeApiService = pokeApiService;
        }

        [RelayCommand]
        public async Task InitializePokemons()
        {
            if (Pokemons.Any())
                return;

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

        [RelayCommand]
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

        [RelayCommand]
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

        [RelayCommand]
        public async Task GoToPokemonDetail(Pokemon pokemon)
        {
            if (pokemon is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(PokemonDetailPage)}", true,
                new Dictionary<string, object>
                {
                    {"Pokemon", pokemon}
                });

            SelectedPokemon = null;
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
