using AspNetCoreGraphQLClient.Models; 

namespace AspNetCoreGraphQLClient.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetAllPlayersAsync();
    }
}