using AspNetCoreGraphQLClient.Models;

using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace AspNetCoreGraphQLClient.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IGraphQLClient _client;

        public PlayerService(IGraphQLClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            var request = new GraphQLRequest
            {
                Query = @"
                {
                    players {
                        id
                        name,
                        shirtNo,
                        appearances,
                        goals
                    }
                }"
            };

            var response =  await _client.SendQueryAsync<PlayersResponseType>(request);
            return response.Data.Players;
        }
    }
}
