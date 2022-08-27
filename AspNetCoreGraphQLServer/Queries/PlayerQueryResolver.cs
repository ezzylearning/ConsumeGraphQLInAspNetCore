using AspNetCoreGraphQLServer.Models;
using AspNetCoreGraphQLServer.Services;

namespace AspNetCoreGraphQLServer.Queries
{
    [ExtendObjectType("Query")]
    public class PlayerQueryResolver
    {
        [GraphQLName("players")]
        [GraphQLDescription("Players API")]
        public async Task<IEnumerable<Player>> GetAllPlayersAsync(
          [Service] IPlayerService playerService)
        {
            return await playerService.GetAllPlayersAsync();
        }
    }
}
