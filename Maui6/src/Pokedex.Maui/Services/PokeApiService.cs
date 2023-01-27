using PokeApiNet;
using Type = PokeApiNet.Type;

namespace Pokedex.Maui.Services
{
    public class PokeApiService : IPokeApiService
    {
        public async Task<IEnumerable<Pokemon>> GetPokemonsAsync(int limit, int offset)
        {
            using (var client = new PokeApiClient())
            {
                var pokemonsPage = await client.GetNamedResourcePageAsync<Pokemon>(limit, offset);

                return await client.GetResourceAsync<Pokemon>(pokemonsPage.Results);
            }
        }

        public async Task<IEnumerable<Ability>> GetPokemonAbilitiesAsync(Pokemon pokemon)
        {
            using (var client = new PokeApiClient())
            {
                return await client.GetResourceAsync<Ability>(pokemon.Abilities.Select(a => a.Ability));
            }
        }

        public async Task<IEnumerable<Move>> GetPokemonMovesAsync(Pokemon pokemon)
        {
            using (var client = new PokeApiClient())
            {
                return await client.GetResourceAsync<Move>(pokemon.Moves.Select(m => m.Move));
            }
        }

        public async Task<IEnumerable<Type>> GetPokemonTypesAsync(Pokemon pokemon)
        {
            using (var client = new PokeApiClient())
            {
                return await client.GetResourceAsync<Type>(pokemon.Types.Select(t => t.Type));
            }
        }
    }
}
