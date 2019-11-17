using AtaTennisApp.BL.DTO;
using AtaTennisApp.BL.Helper;
using AtaTennisApp.Data;
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
    public class TournamentFilter
    {
        public int? Id { get; set; }
        public int? Year { get; set; }
        public TournamentType? Type { get; set; }
    }

    public interface ITournamentService
    {
        Task<TournamentDTO> GetNearestTournament();
        Task<List<TournamentDTO>> GetFilteredTournaments(TournamentFilter filter);
        Task<TournamentDTO> AddOrEditTournament(TournamentDTO tournamentDTO);
        Task<List<TournamentDTO>> GetTournamentsByName(string name);
    }
    public class TournamentService : ITournamentService
    {
        private AtaTennisContext _dbContext { get; set; }
        private IMapper Mapper { get; set; } = MapperHelper.GetTournamentMapper();

        public TournamentService(AtaTennisContext context)
        {
            _dbContext = context;
        }

        public async Task<List<TournamentDTO>> GetFilteredTournaments(TournamentFilter filter)
        {
            var list = new List<TournamentDTO>();

            if (filter.Id != null)
            {
                // for testing purpose
                //throw new Exception("I throw tournament exception");
                var tournamentList = await _dbContext.Tournament.Where(t => t.Id == filter.Id).ToListAsync();
                foreach (var tournament in tournamentList)
                {
                    var tournamentDto = Mapper.Map<Tournament, TournamentDTO>(tournament);
                    list.Add(tournamentDto);
                }
            }
            else if (filter.Year != null)
            {
                var tournamentQueryable = _dbContext.Tournament.Where(t => t.StartTime.Year == filter.Year);

                if (filter.Type != null)
                {
                    tournamentQueryable = tournamentQueryable.Where(t => t.TournamentType == filter.Type);
                }

                var tournamentList = await tournamentQueryable.ToListAsync();

                foreach (var tournament in tournamentList)
                {
                    var tournamentDto = Mapper.Map<Tournament, TournamentDTO>(tournament);
                    list.Add(tournamentDto);
                }
            }

            return list;
        }

        public async Task<List<TournamentDTO>> GetTournamentsByName(string name)
        {
            var list = new List<TournamentDTO>();
            var tournamentList = await _dbContext.Tournament.Where(t => t.Name.ToLower()
                .Contains(name.ToLower())).Take(5).ToListAsync();

            foreach (var tournament in tournamentList)
            {
                var tournamentDto = Mapper.Map<Tournament, TournamentDTO>(tournament);
                list.Add(tournamentDto);
            }

            return list;
        }

        public async Task<TournamentDTO> GetNearestTournament()
        {
            var tournament = await _dbContext.Tournament.Where(t => t.StartTime > DateTime.Now)
                .OrderBy(t=> t.StartTime).FirstOrDefaultAsync();

            var tournamentDto = Mapper.Map<Tournament, TournamentDTO>(tournament);
            return tournamentDto;
        }

        public async Task<TournamentDTO> AddOrEditTournament(TournamentDTO tournamentDTO)
        {
            var tournament = Mapper.Map<TournamentDTO, Tournament>(tournamentDTO);
            if (tournamentDTO.Id > 0)
            {
                var currentTournament = await _dbContext.Tournament.Where(t => t.Id == tournamentDTO.Id).FirstOrDefaultAsync();
                _dbContext.Entry(currentTournament).CurrentValues.SetValues(tournament);
            }
            else
            {
                await _dbContext.Tournament.AddAsync(tournament);
            }

            await _dbContext.SaveChangesAsync();
            var updatedTournamentDto = Mapper.Map<Tournament, TournamentDTO>(tournament);

            return updatedTournamentDto;
        }
    }
}
