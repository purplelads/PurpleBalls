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
    }
}
