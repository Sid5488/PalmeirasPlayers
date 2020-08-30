using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PalmeirasPlayers.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Cryptography.X509Certificates;
using PalmeirasPlayers.Repositories;
using PalmeirasPlayers.Services;
using Microsoft.AspNetCore.Cors;
using System;

namespace PalmeirasPlayers.Controllers
{
    [ApiController]
    [Route("/api/players")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController( 
            IPlayerService playerService
        )
        {
            _playerService = playerService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Players>>> GetAll()
        {
            var players = await _playerService.GetAll();

            return players;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Players>> GetById(int id)
        {
            var player = await _playerService.GetById(id);

            return player;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Insert([FromBody] Players player)
        {
            var playerCount = _playerService.GetTotalPlayers();

            if(playerCount >= 22)
            {
                return BadRequest("Execption total of players");
            }

            var playerResult = _playerService.Insert(player);

            return Ok(playerResult);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public Players Update(
            [FromBody] Players player,
            int id
        )
        {
            var playerUpdate = _playerService.Update(player, id);

            return playerUpdate;
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public void Delete(int id)
        {
            _playerService.Delete(id);
        }
    }
}
