using AtaTennisApp.BL.DTO;
using AtaTennisApp.BL.Helper;
using AtaTennisApp.BL.Helper.Mapper;
using AtaTennisApp.Data.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtaTennisApp.BL
{
    public interface ITournamentEntryService
    {
        Task<List<PlayerDrawDTO>> GetTournamentPlayers(int tournamentId);
        Task<List<PlayerDrawDTO>> GetSearchedPlayers(string nameSurname);
        Task<TournamentEntryDTO> AddTournamentPlayer(int tournamentId, int playerId);
        Task DeleteTournamentPlayer(int tournamentEntryId);
    }
    public class TournamentEntryService : ITournamentEntryService
    {
        private AtaTennisContext _dbContext { get; set; }
        private MapperConfiguration PlayerMapperConfig { get; set; } = MapperHelper.GetPlayerDrawConfig();
        //private IMapper TournamentEntryMapper { get; set; } = MapperHelper.GetTournamentEntryMapper();

        public TournamentEntryService(AtaTennisContext context)
        {
            _dbContext = context;
        }

        public async Task<TournamentEntryDTO> AddTournamentPlayer(int tournamentId, int playerId)
        {
            var tournamentEntryDTO = new TournamentEntryDTO { PlayerId = playerId, TournamentId = tournamentId };

            var tournamentEntryDb = await _dbContext.TournamentEntries
                .AddAsync(new TournamentEntry { PlayerId = playerId, TournamentId = tournamentId });


            await _dbContext.SaveChangesAsync();

            var tournamentEntryDto = TournamentEntryMapper.MapToDTO(tournamentEntryDb.Entity);
            //tournamentEntryDb.MapTo()

            //TournamentEntryMapper.Map<TournamentEntry, TournamentEntryDTO>(tournamentEntryDb);
            //var tournamentEntryDto = tournamentEntryDb.ProjectTo<TournamentEntryDTO>(TournamentEntryMapper).FirstOrDefault();

            return tournamentEntryDto;
        }

        public async Task<List<PlayerDrawDTO>> GetTournamentPlayers(int tournamentId)
        {
            var players = await _dbContext.TournamentEntries.Where(e => e.TournamentId == tournamentId)

                .Select(te => new PlayerDrawDTO()
                {
                    TournamentEntryId = te.Id,
                    PlayerId = te.Player.Id,
                    Name = te.Player.Name,
                    Surname = te.Player.Surname
                })
                //.ProjectTo<PlayerDrawDTO>(Mapper)
                .ToListAsync();

            return players;
        }

        public async Task<List<PlayerDrawDTO>> GetSearchedPlayers(string nameSurname)
        {
            var searchSubstring = nameSurname.ToLower();
            var players = await _dbContext.Players.Where(p => p.Surname.ToLower().Contains(searchSubstring)
                || p.Name.ToLower().Contains(searchSubstring)).Take(5)
                .ProjectTo<PlayerDrawDTO>(PlayerMapperConfig)
                .ToListAsync();

            return players;
        }

        public async Task DeleteTournamentPlayer(int tournamentEntryId)
        {
            //var entry = _dbContext.TournamentEntries.Select(e => e.TournamentId == tournamentId && e.PlayerId == playerId);
            var entry = new TournamentEntry() { Id = tournamentEntryId };
            _dbContext.TournamentEntries.Remove(entry);
            await _dbContext.SaveChangesAsync();
        }
    }
}
