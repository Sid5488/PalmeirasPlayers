using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PalmeirasPlayers.Data;
using PalmeirasPlayers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalmeirasPlayers.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DbPlayerContext _context;

        public PlayerRepository(DbPlayerContext context)
        {
            _context = context;
        }

        public async Task<List<Players>> GetAll()
        {
            var players = await _context.PlayerList
                .ToListAsync();

            return players;
        }

        Players IPlayerRepository.Save(Players player)
        {
            _context.PlayerList.Add(player);
            _context.SaveChanges();

            return player;
        }

        public void Delete(int id)
        {
            Players player = _context.PlayerList
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (player != null)
            {
                _context.PlayerList.Remove(player);
                _context.SaveChanges();
            }
        }

        public Task<Players> GetById(int playerId)
        {
            var player = _context.PlayerList
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == playerId);

            return player;
        }

        Players IPlayerRepository.Update(Players player)
        {
            _context.PlayerList.Update(player);
            _context.SaveChanges();

            return player;
        }

        public int GetTotalPlayers()
        {
            var count = _context.PlayerList.Count();

            return count;
        }
    }
}