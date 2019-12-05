using AtaTennisApp.BL.DTO;
using AtaTennisApp.BL.Helper;
using AtaTennisApp.Data;
using AtaTennisApp.Data.Entities;
using AutoMapper;
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

        Task CreateDraw(int drawCount, int tournamentId);
    }

    public class MatchService : IMatchService
    {
        private AtaTennisContext _dbContext { get; set; }
        //private IMapper Mapper { get; set; } = MapperHelper.GetTournamentMapper();

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
        public async Task CreateDraw(int playerCount, int tournamentId)
        {
            var startingRound = 1;
            var qualificationPlayersCount = 0;
            var matchesCount = 0;
            var qualificationMatchesCount = 0;

            var matches = new List<Match>();

            if (playerCount <= (int)DrawSize.draw16)
            {
                startingRound = 4;
                matchesCount = playerCount/2;
            }
            else if (playerCount <= (int)DrawSize.draw32)
            {
                startingRound = 3;
                qualificationPlayersCount = playerCount - (int)DrawSize.draw16;
            }
            else if (playerCount <= (int)DrawSize.draw64)
            {
                startingRound = 2;
                qualificationPlayersCount = playerCount - (int)DrawSize.draw32;
            }

            matches = Enumerable.Repeat(new Match() { Round = startingRound }, matchesCount).ToList();


            if (true)
            {

            }

            _dbContext.Matches.AddRange(matches);
            await _dbContext.SaveChangesAsync();
        }
    }
}
