using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PurpleBalls.Data.Models;
using PurpleBalls.Services.Players;

namespace PurpleBalls.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly IPlayersService _playersService;

        public PlayersController(IPlayersService playersService)
        {
            _playersService = playersService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await _playersService.GetAllPlayers();
        }
    }
}
