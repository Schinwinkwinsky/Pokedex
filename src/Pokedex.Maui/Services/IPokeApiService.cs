using PokeApiNet;
using Type = PokeApiNet.Type;

namespace Pokedex.Maui.Services
{
    public interface IPokeApiService
    {
        Task<IEnumerable<Pokemon>> GetPokemonsAsync(int limit, int offset);
        Task<IEnumerable<Ability>> GetPokemonAbilitiesAsync(Pokemon pokemon);
        Task<IEnumerable<Move>> GetPokemonMovesAsync(Pokemon pokemon);
        Task<IEnumerable<Type>> GetPokemonTypesAsync(Pokemon pokemon);
    }
}
