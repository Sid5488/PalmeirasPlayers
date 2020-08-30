using PalmeirasPlayers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalmeirasPlayers.Repositories
{
    public interface IPlayerRepository
    {
        Task<List<Players>> GetAll();
        int GetTotalPlayers();
        Task<Players> GetById(int playerId);
        Players Save(Players player);
        Players Update(Players player);
        void Delete(int playerId);
    }
}
