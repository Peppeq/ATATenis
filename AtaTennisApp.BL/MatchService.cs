using AtaTennisApp.BL.DTO;
using AtaTennisApp.BL.Helper;
using AtaTennisApp.Data;
using AtaTennisApp.Data.Entities;
using AutoMapper;
using EFCore.BulkExtensions;
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
        Task<List<MatchDTO>> CreateMatchesForTournament(DrawSize drawSize, int tournamentId);
    }

    public class MatchService : IMatchService
    {
        private AtaTennisContext _dbContext { get; set; }
        private IMapper Mapper { get; set; } = MapperHelper.GetMatchMapper();

        public MatchService(AtaTennisContext context)
        {
            _dbContext = context;
        }

        public Task<List<MatchDTO>> GetMatchesByPlayer(int playerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchDTO>> GetMatchesByTournament(int tournamentId)
        {
            throw new NotImplementedException();
        }

        //porozmyslat ako spravim draw ci tam dam poradie alebo ako..
        // netreba drawOrder lebo mam parentMatch a podla toho urcim order
        // vygenerujem vsetky matche podla player countu cize velkosti pavuka pre nasledujuce kolo
        // pridam dalsie matche (parent match ) pre aktualne vygenerovane 
        // na frontende budem vediet podla id matchu 1 kola a parenta urcit aj order pre predkolo
        // porozmyslat ako navrhnem na FE pridavanie predkol
        public async Task<List<MatchDTO>> CreateMatchesForTournament(DrawSize drawSize, int tournamentId)
        {
            var startingRound = 0;
            var matchesCount = 0;

            switch (drawSize)
            {
                case DrawSize.draw8:
                    startingRound = 4;
                    matchesCount = (int)DrawSize.draw8 / 2;
                    break;
                case DrawSize.draw16: 
                    startingRound = 3;
                    matchesCount = (int)DrawSize.draw16 / 2;
                    break;
                case DrawSize.draw32:
                    startingRound = 2;
                    matchesCount = (int)DrawSize.draw32 / 2;
                    break;
                case DrawSize.draw64:
                    startingRound = 1;
                    matchesCount = (int)DrawSize.draw64 / 2;
                    break;
            };

            var matches = Enumerable.Repeat(new Match() { Round = startingRound, TournamentId = tournamentId }, matchesCount).ToList();
            var bulkConfig = new BulkConfig { PreserveInsertOrder = true, SetOutputIdentity = true };
            _dbContext.BulkInsert(matches, bulkConfig);
            await _dbContext.SaveChangesAsync();
            var matchDTOs = Mapper.Map<List<Match>, List<MatchDTO>>(matches);

            return matchDTOs;
        }
    }
}
