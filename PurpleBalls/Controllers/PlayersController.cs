﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        [Route("")]
        [HttpPost]
        public async Task<Player> AddPlayer([FromBody] Player player)
        {
            return await _playersService.AddPlayer(player);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<ActionResult> DeletePlayer(int id)
        {
            if (!await _playersService.DeletePlayer(id))
            {
                return NotFound();
            }

            return Ok();
        }

        [Route("shirts")]
        [HttpGet]
        public async Task<IEnumerable<PlayerShirt>> GetPlayerShirts()
        {
            return await _playersService.GetPlayerShirts();
        }

        [Route("saveShirt")]
        [HttpPost]
        public async Task<ActionResult> SavePlayerShirt([FromBody] PlayerShirt shirt)
        {
            if (!await _playersService.SavePlayerShirt(shirt))
            {
                return BadRequest();
            };

            return Ok();
        }
    }
}
