using AspNetCoreGraphQLServer.Data;
using AspNetCoreGraphQLServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreGraphQLServer.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly SportsDbContext _context;

        public PlayerService(SportsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            return await _context.Players
                .Include(x => x.Position)
                .ToListAsync();
        }

        public async Task<Player> GetPlayerAsync(int id)
        {
            return await _context.Players
                .Include(x => x.Position)
                .Where(x => x.Id == id)
                .SingleAsync();
        }

        public async Task<Player> CreatePlayerAsync(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<int> UpdatePlayerAsync(Player player)
        {
            _context.Players.Update(player);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePlayerAsync(Player player)
        {
            _context.Players.Remove(player);
            return await _context.SaveChangesAsync();
        }
    }
}
