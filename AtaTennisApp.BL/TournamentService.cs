using AtaTennisApp.BL.DTO;
using AtaTennisApp.BL.Helper;
using AtaTennisApp.Data;
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
    public interface ITournamentService
    {
        Task<TournamentDTO> GetNearestTournament();
        Task<List<TournamentDTO>> GetFilteredTournaments(TournamentFilterDTO filter);
        Task<TournamentDTO> AddOrEditTournament(TournamentDTO tournamentDTO);
        Task<List<TournamentDTO>> GetTournamentsByName(string name);
        Task<List<SearchedTournamentDTO>> GetSearchedTournamentsByName(string name);
        Task<TournamentGraphDTO> GetTournamentGraph(int tournamentId);
    }
    public class TournamentService : ITournamentService
    {
        private AtaTennisContext _dbContext { get; set; }
        private IMapper Mapper { get; set; } = MapperHelper.GetMapper();

        public TournamentService(AtaTennisContext context)
        {
            _dbContext = context;
        }

        public async Task<List<TournamentDTO>> GetFilteredTournaments(TournamentFilterDTO filter)
        {
            var list = new List<TournamentDTO>();

            if (filter.Id != null)
            {
                // for testing purpose
                //throw new Exception("I throw tournament exception");
                var tournamentList = await _dbContext.Tournaments.Where(t => t.Id == filter.Id).ToListAsync();
                foreach (var tournament in tournamentList)
                {
                    var tournamentDto = Mapper.Map<Tournament, TournamentDTO>(tournament);
                    list.Add(tournamentDto);
                }
            }
            else if (filter.Year != null)
            {
                var tournamentQueryable = _dbContext.Tournaments.Where(t => t.StartTime.Year == filter.Year);

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
            var tournamentList = await _dbContext.Tournaments.Where(t => t.Name.ToLower()
                .Contains(name.ToLower())).Take(5).ToListAsync();

            foreach (var tournament in tournamentList)
            {
                var tournamentDto = Mapper.Map<Tournament, TournamentDTO>(tournament);
                list.Add(tournamentDto);
            }

            return list;
        }

        public async Task<List<SearchedTournamentDTO>> GetSearchedTournamentsByName(string name)
        {
            var tournamentList = await _dbContext.Tournaments.Where(t => t.Name.ToLower()
                .Contains(name.ToLower())).Take(5).Select(t => new SearchedTournamentDTO()
                {
                    Name = t.Name,
                    TournamentId = t.Id,
                    StartTime = t.StartTime
                }).ToListAsync();

            return tournamentList;
        }

        public async Task<TournamentDTO> GetNearestTournament()
        {
            var tournament = await _dbContext.Tournaments
                //.Where(t => t.StartTime > DateTime.Now)
                .OrderBy(t => t.StartTime).FirstOrDefaultAsync();

            var tournamentDto = Mapper.Map<Tournament, TournamentDTO>(tournament);
            return tournamentDto;
        }

        public async Task<TournamentDTO> AddOrEditTournament(TournamentDTO tournamentDTO)
        {
            var tournament = Mapper.Map<TournamentDTO, Tournament>(tournamentDTO);
            if (tournamentDTO.Id > 0)
            {
                var currentTournament = await _dbContext.Tournaments.Where(t => t.Id == tournamentDTO.Id).FirstOrDefaultAsync();
                _dbContext.Entry(currentTournament).CurrentValues.SetValues(tournament);
            }
            else
            {
                await _dbContext.Tournaments.AddAsync(tournament);
            }

            await _dbContext.SaveChangesAsync();
            var updatedTournamentDto = Mapper.Map<Tournament, TournamentDTO>(tournament);

            return updatedTournamentDto;
        }

        public async Task<TournamentGraphDTO> GetTournamentGraph(int tournamentId)
        {
            var tournamentGraph = new TournamentGraphDTO();
            var tournament = await _dbContext.Tournaments.Where(t => t.Id == tournamentId)
                .Include(t => t.TournamentEntries)
                .ThenInclude(te => te.Player)
                .Include(t => t.Matches)
                .ThenInclude(t => t.MatchEntries)
                .ThenInclude(me => me.Scores)
                .FirstOrDefaultAsync();
            //tournamentPlayersQuery.ma
            tournamentGraph = Mapper.Map<Tournament, TournamentGraphDTO>(tournament);
            tournamentGraph.Draw = new DrawDTO();

            if (tournament.Matches != null && tournament.Matches.Count > 0)
            {
                tournamentGraph.Draw.InitialRound = tournament.Matches?.Min(m => m.Round) ?? 0;
                tournamentGraph.Draw.MatchesCount = tournament.Matches.Count;
                var matchesDto = Mapper.Map<List<Match>, List<MatchDTO>>(tournament.Matches.ToList());
                var groupMatchesDTO = matchesDto.GroupBy(m => m.Round).Select(g => new RoundMatchDTO { Round = (int)g.Key, Matches = g.ToList() });
                tournamentGraph.Draw.RoundMatches = groupMatchesDTO.OrderBy(gm => gm.Round).ToList();
            }

            if (tournament.TournamentEntries != null && tournament.TournamentEntries.Count > 0)
            {
                tournamentGraph.Players =
                    tournament.TournamentEntries.Select(te => new PlayerDrawDTO { Name = te.Player?.Name, PlayerId = te.PlayerId, Surname = te.Player?.Surname, TournamentEntryId = te.Id }).ToList();
            }
            //var tournamentPlayers = await _dbContext.Tournaments.Where(t => t.Id == tournamentId)
            //   .ProjectTo<TournamentGraphDTO>(MapperHelper.Configuration)
            //   .FirstOrDefaultAsync();

            return tournamentGraph;
        }

    }
}
