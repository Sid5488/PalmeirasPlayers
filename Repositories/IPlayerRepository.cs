using PalmeirasPlayers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalmeirasPlayers.Repositories
{
    interface IPlayerRepository
    {
        Task<List<Players>> GetAll();
        Players Save(Players player);
        Players Update(Players player);
        void Delete(int playerId);
    }
}
