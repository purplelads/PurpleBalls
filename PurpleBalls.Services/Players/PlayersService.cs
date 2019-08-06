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
    }
}
