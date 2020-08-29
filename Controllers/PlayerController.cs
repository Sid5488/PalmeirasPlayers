using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PalmeirasPlayers.Data;
using PalmeirasPlayers.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Cryptography.X509Certificates;
using PalmeirasPlayers.Repositories;

namespace PalmeirasPlayers.Controllers
{
    [ApiController]
    [Route("/api/players")]
    public class PlayerController : ControllerBase
    {
        private readonly DbPlayerContext _context;

        public PlayerController(DbPlayerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Players>>> GetAll()
        {
            var players = await _context.PlayerList.ToListAsync();

            return players;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Players>> GetById(int id)
        {
            var player = await _context.PlayerList
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return player;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Players>> Insert([FromBody] Players player)
        {
            if (ModelState.IsValid)
            {
                _context.PlayerList.Add(player);
                await _context.SaveChangesAsync();

                return player;
            }
            else
                return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<ActionResult<Players>> Update(
            [FromBody] Players player,
            int id
        )
        {
            if (ModelState.IsValid)
            {
                Players playerFind = _context.PlayerList
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Id == id);

                playerFind.Id = id;
                playerFind.Name = player.Name;
                playerFind.PlayingPosition = player.PlayingPosition;
                playerFind.ShirtNumber = player.ShirtNumber;
                playerFind.Age = player.Age;

                _context.Update(playerFind);
                _context.SaveChanges();

                return playerFind;
            }

            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public void Delete(int id)
        {
            var player = _context.PlayerList
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (player == null) BadRequest();

            _context.Remove(player);
            _context.SaveChanges();
        }
    }
}
