using AspNetCoreGraphQLServer.Models;
using AspNetCoreGraphQLServer.Services;

namespace AspNetCoreGraphQLServer.Mutations
{
    [ExtendObjectType("Mutation")]
    public class PlayerMutationResolver
    {
        [GraphQLName("createPlayer")]
        [GraphQLDescription("Create New Player")]
        public async Task<Player> CreatePlayerAsync(PlayerInput playerInput,
            [Service] IPlayerService playerService)
        {
            var player = new Player()
            {
                ShirtNo = playerInput.ShirtNo,
                Name = playerInput.Name,
                PositionId = playerInput.PositionId,
                Appearances = playerInput.Appearances,
                Goals = playerInput.Goals
            };

            return await playerService.CreatePlayerAsync(player);
        }

        [GraphQLName("updatePlayer")]
        [GraphQLDescription("Update Player")]
        public async Task<Player> UpdatePlayerAsync(int id, PlayerInput playerInput,
        [Service] IPlayerService playerService)
        {
            var player = await playerService.GetPlayerAsync(id);
            if (player == null)
            {
                throw new GraphQLException(new Error("Player not found.", "PLAYER_NOT_FOUND"));
            }

            player.ShirtNo = playerInput.ShirtNo;
            player.Name = playerInput.Name;
            player.PositionId = playerInput.PositionId;
            player.Appearances = playerInput.Appearances;
            player.Goals = playerInput.Goals;

            await playerService.UpdatePlayerAsync(player);

            return player;
        }

        [GraphQLName("deletePlayer")]
        [GraphQLDescription("Delete Player")]
        public async Task<int> DeletePlayerAsync(int id,
        [Service] IPlayerService playerService)
        {
            var player = await playerService.GetPlayerAsync(id);
            if (player == null)
            {
                throw new GraphQLException(new Error("Player not found.", "PLAYER_NOT_FOUND"));
            }

            return await playerService.DeletePlayerAsync(player);
        }
    }
}
