using AtaTennisApp.BL.DTO;
using AtaTennisApp.Data.Entities;

namespace AtaTennisApp.BL.Helper.Mapper
{
    public static class PlayerMapper
    {
        public static PlayerDTO MapToDTO(Player player)
        {
            if (player == null)
                return null;

            return new PlayerDTO
            {
                Id = player.Id,
                Name = player.Name,
                Surname = player.Surname,
                BirthDate = player.BirthDate,
                Height = player.Height,
                Weight = player.Weight,
                Residence = player.Residence,
                Forehand = player.Forehand,
                Backhand = player.Backhand,
                Racquet = player.Racquet,
                Surface = player.Surface,
                FavouritePlayer = player.FavouritePlayer,
                Member = player.Member,
                Points = player.Points
            };
        }

        public static Player MapToEntity(PlayerDTO playerDTO)
        {
            if (playerDTO == null)
                return null;

            return new Player
            {
                Id = playerDTO.Id,
                Name = playerDTO.Name,
                Surname = playerDTO.Surname,
                BirthDate = playerDTO.BirthDate,
                Height = playerDTO.Height,
                Weight = playerDTO.Weight,
                Residence = playerDTO.Residence,
                Forehand = playerDTO.Forehand,
                Backhand = playerDTO.Backhand,
                Racquet = playerDTO.Racquet,
                Surface = playerDTO.Surface,
                FavouritePlayer = playerDTO.FavouritePlayer,
                Member = playerDTO.Member,
                Points = playerDTO.Points
            };
        }
    }
}
