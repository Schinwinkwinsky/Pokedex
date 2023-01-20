using PokeApiNet;
using Type = PokeApiNet.Type;

namespace Pokedex.Maui.Services
{
    public interface IPokeApiService
    {
        Task<IEnumerable<Pokemon>> GetPokemons(int limit, int offset);
        Task<PokemonSpecies> GetPokemonSpecies(Pokemon pokemon);
        Task<IEnumerable<Type>> GetPokemonTypes(Pokemon pokemon);
    }
}
