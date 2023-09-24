using AtaTennisApp.BL.DTO;
using AtaTennisApp.Data.Entities;

namespace AtaTennisApp.BL.Helper.Mapper
{
    public static class TournamentMapper
    {
        public static TournamentDTO MapToDTO(Tournament tournament)
        {
            if (tournament == null)
                return null;

            return new TournamentDTO
            {
                Id = tournament.Id,
                Name = tournament.Name,
                StartTime = tournament.StartTime,
                EndTime = tournament.EndTime,
                Place = tournament.Place,
                Category = tournament.Category,
                PlayingSystem = tournament.PlayingSystem,
                BallsType = tournament.BallsType,
                TournamentType = tournament.TournamentType,
                Surface = tournament.Surface,
                Description = tournament.Description
            };
        }

        public static Tournament MapToEntity(TournamentDTO tournamentDTO)
        {
            if (tournamentDTO == null)
                return null;

            return new Tournament
            {
                Id = tournamentDTO.Id,
                Name = tournamentDTO.Name,
                StartTime = tournamentDTO.StartTime,
                EndTime = tournamentDTO.EndTime.Value,
                Place = tournamentDTO.Place,
                Category = tournamentDTO.Category,
                PlayingSystem = tournamentDTO.PlayingSystem,
                BallsType = tournamentDTO.BallsType,
                TournamentType = tournamentDTO.TournamentType,
                Surface = tournamentDTO.Surface,
                Description = tournamentDTO.Description
            };
        }
    }
}
