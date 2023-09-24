using AtaTennisApp.Data.Entities;

namespace AtaTennisApp.BL.Helper.Mapper
{
    public static class TournamentEntryMapper
    {
        public static TournamentEntryDTO MapToDTO(this TournamentEntry entry)
        {
            if (entry == null)
                return null;

            return new TournamentEntryDTO
            {
                Id = entry.Id,
                TournamentId = entry.TournamentId,
                PlayerId = entry.PlayerId,
                Tournament = TournamentMapper.MapToDTO(entry.Tournament),
                Player = PlayerMapper.MapToDTO(entry.Player)
            };
        }

        public static TournamentEntry MapToEntity(this TournamentEntryDTO entryDTO)
        {
            if (entryDTO == null)
                return null;

            return new TournamentEntry
            {
                Id = entryDTO.Id,
                TournamentId = entryDTO.TournamentId,
                PlayerId = entryDTO.PlayerId,
                Tournament = TournamentMapper.MapToEntity(entryDTO.Tournament),
                Player = PlayerMapper.MapToEntity(entryDTO.Player)
            };
        }
    }
}
