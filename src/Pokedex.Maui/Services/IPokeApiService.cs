using PokeApiNet;

namespace Pokedex.Maui.Services
{
    public interface IPokeApiService
    {
        Task<IEnumerable<Pokemon>> GetPokemons(int limit, int offset);
    }
}
