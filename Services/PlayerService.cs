using Microsoft.AspNetCore.Mvc;
using PalmeirasPlayers.Data;
using PalmeirasPlayers.Domain.Models;
using PalmeirasPlayers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalmeirasPlayers.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public int GetTotalPlayers()
        {
            var count = _repository.GetTotalPlayers();

            return count;
        }

        public async Task<ActionResult<List<Players>>> GetAll()
        {
            var players = await _repository.GetAll();

            return players;
        }

        public async Task<Players> GetById(int playerId)
        {
            var player = await _repository.GetById(playerId);

            return player;
        }

        public Players Insert(Players player)
        {
            var playerResult = _repository.Save(player);

            return playerResult;
        }

        Players IPlayerService.Update(Players player, int id)
        {
            player.Id = id;

            _repository.Update(player);

            return player;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
