using AspNetCoreGraphQLServer.Models;

namespace AspNetCoreGraphQLServer.Services
{
    public interface IPlayerService
    {
        Task<Player> CreatePlayerAsync(Player player);
        Task<int> UpdatePlayerAsync(Player player);
        Task<int> DeletePlayerAsync(Player player);
        Task<Player> GetPlayerAsync(int id);
        Task<IEnumerable<Player>> GetAllPlayersAsync();
    }
}