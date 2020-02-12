using AtaTennisApp.BL.DTO;
using AtaTennisApp.BL.Helper;
using AtaTennisApp.Data;
using AtaTennisApp.Data.Entities;
using AutoMapper;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtaTennisApp.BL
{
    public interface IMatchService
    {
        Task<List<MatchDTO>> GetMatchesByTournament(int tournamentId);
        Task<List<MatchDTO>> GetMatchesByPlayer(int playerId);
        Task<List<MatchDTO>> CreateOrUpdateMatchesForTournament(DrawSize drawSize, int tournamentId, List<MatchDTO> matchDTOs);
        Task<MatchDTO> CreateQualificationMatch(int childMatchId, int round);
        Task DeleteMatchesGraph(int tournamentId);
    }

    public class MatchService : IMatchService
    {
        private AtaTennisContext _dbContext { get; set; }
        private IMapper Mapper { get; set; } = MapperHelper.Configuration.CreateMapper();

        public MatchService(AtaTennisContext context)
        {
            _dbContext = context;
        }

        public Task<List<MatchDTO>> GetMatchesByPlayer(int playerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MatchDTO>> GetMatchesByTournament(int tournamentId)
        {
            var matches = await _dbContext.Matches.Where(m => m.TournamentId == tournamentId).Include(m => m.MatchEntries).ToListAsync();
            var matchesDTO = Mapper.Map<List<Match>, List<MatchDTO>>(matches);
            return matchesDTO;
        }

        public async Task<List<MatchDTO>> CreateOrUpdateMatchesForTournament(DrawSize drawSize, int tournamentId, List<MatchDTO> matchDTOs = null)
        {
            var matches = await _dbContext.Matches.Where(m => m.TournamentId == tournamentId).ToListAsync();

            if (matches == null || matches.Count == 0)
            {
                var startingRound = TournamentRound.round1;
                var matchesCount = 0;

                var draw = InitializeDraw(drawSize, startingRound, matchesCount);

                matches = GetMatchesForNewDraw(draw.InitialRound, draw.MatchesCount, tournamentId);

                // reverse matches because when not In DB stored first match is final(round6), then round5, round4..
                matches.Reverse();

                var matchesEntries = new List<MatchEntry>();

                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var bulkConfig = new BulkConfig { PreserveInsertOrder = true, SetOutputIdentity = true };
                    _dbContext.BulkInsert(matches, bulkConfig);
                    int matchIndex = 0, round2index = 0;

                    foreach (var match in matches)
                    {
                        if (match.Round != draw.InitialRound)
                        {
                            foreach (var entry in match.MatchEntries)
                            {
                                entry.MatchId = match.Id;
                                entry.ParentMatchId = matches[round2index].Id;
                                round2index++;
                            }
                        }
                        else
                        {
                            foreach (var entry in match.MatchEntries)
                            {
                                entry.MatchId = match.Id;
                            }
                        }
                        matchesEntries.AddRange(match.MatchEntries);
                        matchIndex++;
                    }
                    _dbContext.BulkInsert(matchesEntries);
                    transaction.Commit();
                }

            }
            else
            {
                // update list MatchDTO, implementovat FE a tak vyskusat
                // TODO - nejaky check na parent a winner
                var matchesDB = Mapper.Map<List<MatchDTO>, List<Match>>(matchDTOs);
                var matchesEntries = matchesDB.SelectMany(m => m.MatchEntries).ToList();

                CheckMatches(matchesDB);

                await _dbContext.BulkUpdateAsync(matchesDB);
                await _dbContext.BulkUpdateAsync(matchesEntries);
            }

            await _dbContext.SaveChangesAsync();

            // BUG on bulk - need to reverse inserted data
            var reversedMatches = ReverseMatches(matches);
            matchDTOs = Mapper.Map<List<Match>, List<MatchDTO>>(reversedMatches);

            return matchDTOs;
        }

        public async Task<MatchDTO> CreateQualificationMatch(int childMatchId, int round)
        {
            if (round < 2)
            {
                throw new Exception("Cannot create qualification match with round less than 1.");
            }

            var match = new Match() { Round = (TournamentRound)(round - 1) };
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                var entityEntry = _dbContext.Matches.Add(match);
                var matchEntries = new List<MatchEntry>() {
                    new MatchEntry { MatchId = entityEntry.Entity.Id},
                    new MatchEntry { MatchId = entityEntry.Entity.Id}
                };

                // TODO treba testnut
                var childMatchEntry = await _dbContext.MatchEntries.Where(m => m.Id == childMatchId).FirstOrDefaultAsync();
                childMatchEntry.ParentMatchId = entityEntry.Entity.Id;

                _dbContext.MatchEntries.AddRange(matchEntries);
                transaction.Commit();
            }
            await _dbContext.SaveChangesAsync();
            return Mapper.Map<Match, MatchDTO>(match); ;
        }

        private Draw InitializeDraw(DrawSize drawSize, TournamentRound startingRound, int matchesCount)
        {
            var draw = new Draw();

            switch (drawSize)
            {
                case DrawSize.draw8:
                    draw.InitialRound = TournamentRound.round4;
                    draw.MatchesCount = 7;
                    break;
                case DrawSize.draw16:
                    draw.InitialRound = TournamentRound.round3;
                    draw.MatchesCount = 15;
                    break;
                case DrawSize.draw32:
                    draw.InitialRound = TournamentRound.round2;
                    draw.MatchesCount = 31;
                    break;
                case DrawSize.draw64:
                    draw.InitialRound = TournamentRound.round1;
                    draw.MatchesCount = 63;
                    break;
            };

            return draw;
        }

        private List<Match> GetMatchesForNewDraw(TournamentRound startingRound, int matchesCount, int tournamentId)
        {
            var matches = new List<Match>();
            var round = startingRound;

            for (int i = 1; i <= matchesCount; i++)
            {
                if (i == matchesCount) // 15
                    round = TournamentRound.round6;
                else if (i >= matchesCount - 2)  // 13,14 matchesCount - 2
                    round = TournamentRound.round5;
                else if (i >= matchesCount - 6) // 1,2,3,4 matchesCount - 6
                    round = TournamentRound.round4;
                else if (i >= matchesCount - 14) // 14
                    round = TournamentRound.round3;
                else if (i >= matchesCount - 30) // 30
                    round = TournamentRound.round2;
                else
                    round = TournamentRound.round1;

                var match = new Match()
                {
                    Id = 0,
                    Round = round,
                    TournamentId = tournamentId,
                    MatchEntries = new List<MatchEntry>() {
                        new MatchEntry { },
                        new MatchEntry { }
                    }
                };
                matches.Add(match);
            }

            return matches;
        }

        public async Task DeleteMatchesGraph(int tournamentId)
        {
            var matches = _dbContext.Matches.Where(m => m.TournamentId == tournamentId).Include(m => m.MatchEntries);
            _dbContext.MatchEntries.RemoveRange(matches.SelectMany(m => m.MatchEntries));
            _dbContext.Matches.RemoveRange(matches);
            await _dbContext.SaveChangesAsync();
        }

        private void CheckMatches(List<Match> matches)
        {
            matches.ForEach(m =>
            {
                CheckWinner(m);
            });
        }

        private void CheckWinner(Match match)
        {
            if (match.Winner != null)
            {
                var entries = match.MatchEntries.Select(me => me.PlayerId);
                if (!entries.Contains(match.Winner))
                {
                    throw new Exception("Match winner not from entries");
                }
            }
        }

        private List<Match> ReverseMatches(List<Match> matches)
        {
            var newList = matches.ToList();
            newList.Reverse();
            for (int i = 0; i < matches.Count; i++)
            {
                newList[i].Id = matches[i].Id;
            }
            //newList.Reverse();
            return newList;
        }
    }

    internal class Draw
    {
        public TournamentRound InitialRound { get; set; }
        public int MatchesCount { get; set; }
    }

    public interface IDbConnectionProvider
    {
    }
}
