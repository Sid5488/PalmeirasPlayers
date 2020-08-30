using Microsoft.AspNetCore.Mvc;
using PalmeirasPlayers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalmeirasPlayers.Services
{
    public interface IPlayerService
    {
        public Task<ActionResult<List<Players>>> GetAll();
        public Task<Players> GetById(int playerId);
        public int GetTotalPlayers();
        public Players Insert(Players player);
        public Players Update(Players player, int id);
        public void Delete(int id);
    }
}
