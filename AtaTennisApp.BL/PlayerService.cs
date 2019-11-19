using AtaTennisApp.BL.DTO;
using AtaTennisApp.BL.Helper;
using AtaTennisApp.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtaTennisApp.BL
{
    public interface IPlayerService
    {
        Task<PlayerDTO> GetPlayerById(int id);
        Task<List<PlayerDTO>> GetAllPlayers();
        Task<List<PlayerDTO>> GetPlayersByNameSurname(string searchName);
        Task<PlayerDTO> AddOrEditPlayer(PlayerDTO player);
    }
    public class PlayerService : IPlayerService
    {
        private AtaTennisContext _dbContext { get; set; }
        private IMapper Mapper { get; set; } = MapperHelper.GetPlayerMapper();

        public PlayerService(AtaTennisContext context)
        {
            _dbContext = context;
        }

        public async Task<PlayerDTO> GetPlayerById(int id)
        {
            var player = await _dbContext.Players.Where(p => p.Id == id).FirstOrDefaultAsync();
            return Mapper.Map<Player, PlayerDTO>(player);
        }

        public async Task<List<PlayerDTO>> GetAllPlayers()
        {
            var playersDto = new List<PlayerDTO>();
            var players = await _dbContext.Players.OrderByDescending(p => p.Points).ToListAsync();
            foreach (var player in players)
            {
                var playerDto = Mapper.Map<Player, PlayerDTO>(player);
                playersDto.Add(playerDto);
            }
            return playersDto;
        }

        public async Task<PlayerDTO> AddOrEditPlayer(PlayerDTO playerDto)
        {
            var player = Mapper.Map<PlayerDTO, Player>(playerDto);
            if (player.Id == 0)
            {
                await _dbContext.Players.AddAsync(player);
            }
            else
            {
                var currentPlayer = await _dbContext.Players.Where(p => p.Id == player.Id).FirstOrDefaultAsync();
                _dbContext.Entry(currentPlayer).CurrentValues.SetValues(player);
            }

            await _dbContext.SaveChangesAsync();
            var updatedPlayerDto = Mapper.Map<Player, PlayerDTO>(player);

            return updatedPlayerDto;
        }

        public async Task<List<PlayerDTO>> GetPlayersByNameSurname(string searchName)
        {
            var playersDto = new List<PlayerDTO>();
            var searchSubstring = searchName.ToLower();
            var players = await _dbContext.Players.Where(p => p.Surname.ToLower().Contains(searchSubstring) 
                || p.Name.ToLower().Contains(searchSubstring)).Take(5).ToListAsync();
            foreach (var player in players)
            {
                var playerDto = Mapper.Map<Player, PlayerDTO>(player);
                playersDto.Add(playerDto);
            }
            return playersDto;
        }
    }
}
