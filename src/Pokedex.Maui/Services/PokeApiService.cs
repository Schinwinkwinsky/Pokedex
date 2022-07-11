using PokeApiNet;

namespace Pokedex.Maui.Services
{
    public class PokeApiService : IPokeApiService
    {
        public async Task<IEnumerable<Pokemon>> GetPokemons(int limit, int offset)
        {
            using (var client = new PokeApiClient())
            {
                var pokemonsPage = await client.GetNamedResourcePageAsync<Pokemon>(limit, offset);

                return await client.GetResourceAsync<Pokemon>(pokemonsPage.Results);
            }
        }

        public async Task<PokemonSpecies> GetSpecies(Pokemon pokemon)
        {
            using (var client = new PokeApiClient())
            {
                return await client.GetResourceAsync<PokemonSpecies>(pokemon.Species);
            }
        }
    }
}
