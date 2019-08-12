using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PurpleBalls.Data;
using PurpleBalls.Data.Models;

namespace PurpleBalls.Services.Players
{
    public interface IPlayersService
    {
        Task<IEnumerable<Player>> GetAllPlayers();
        Task<Player> AddPlayer(Player player);
        Task<bool> DeletePlayer(int id);
        Task<IEnumerable<PlayerShirt>> GetPlayerShirts();
        Task<bool> SavePlayerShirt(PlayerShirt shirt);
    }

    public class PlayersService : IPlayersService
    {
        private ApplicationDbContext DbContext { get; set; }
        public PlayersService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await DbContext.Players.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Player> AddPlayer(Player player)
        {
            await DbContext.Players.AddAsync(player);
            await DbContext.SaveChangesAsync();

            return player;
        }

        public async Task<bool> DeletePlayer(int id)
        {
            var player = await DbContext.FindAsync<Player>(id);
            if (player == null)
            {
                return false;
            }

            player.IsDeleted = true;
            DbContext.Update(player);
            await DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<PlayerShirt>> GetPlayerShirts()
        {
            return await DbContext.PlayerShirts.ToListAsync();
        }

        public async Task<bool> SavePlayerShirt(PlayerShirt shirt)
        {
            var exists = await DbContext.PlayerShirts.Where(x => x.PlayerId == shirt.PlayerId).FirstOrDefaultAsync();
            if (exists != null)
            {
                try
                {
                    DbContext.Update<PlayerShirt>(shirt);
                    await DbContext.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    await DbContext.AddAsync<PlayerShirt>(shirt);
                    await DbContext.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
