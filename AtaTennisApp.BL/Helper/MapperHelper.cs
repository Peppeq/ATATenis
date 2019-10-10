using AtaTennisApp.BL.DTO;
using AtaTennisApp.Data.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.BL.Helper
{
    public static class MapperHelper
    {
        public static IMapper GetUserMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>()
                    .ForSourceMember(u => u.Id, opt => opt.DoNotValidate());
                cfg.CreateMap<UserDTO, User>()
                    .ForMember(u => u.Id, memberOptions => memberOptions.Ignore());
            });

            return config.CreateMapper();
        }

        public static IMapper GetTournamentMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Tournament, TournamentDTO>()
                    .ForSourceMember(u => u.Draw, opt => opt.DoNotValidate())
                    .ForSourceMember(u => u.Match, opt => opt.DoNotValidate());
                cfg.CreateMap<TournamentDTO, Tournament>();
            });

            return config.CreateMapper();
        }

        public static IMapper GetPlayerMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Player, PlayerDTO>()
                    .ForSourceMember(u => u.MatchPlayer, opt => opt.DoNotValidate());
                cfg.CreateMap<PlayerDTO, Player>();
            });

            return config.CreateMapper();
        }

    }
}
