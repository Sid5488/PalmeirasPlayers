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

        public Players Update(Players player)
        {
            _context.PlayerList.Update(player);
            _context.SaveChangesAsync();

            return player;
        }

        public async void Delete(int id)
        {
            Players player = _context.PlayerList
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (player != null)
            {
                _context.PlayerList.Remove(player);
                await _context.SaveChangesAsync();
            }
        }
    }
}