using AtaTennisApp.BL.DTO;
using AtaTennisApp.Data.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtaTennisApp.BL.Helper
{
    public static class MapperHelper
    {
        public static MapperConfiguration Configuration { get; set; } = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Match, MatchDTO>()
                .ForSourceMember(u => u.Id, opt => opt.DoNotValidate());
            cfg.CreateMap<MatchDTO, Match>()
                .ForMember(u => u.Id, memberOptions => memberOptions.Ignore());
            cfg.CreateMap<MatchEntry, MatchEntryDTO>()
                .ForSourceMember(u => u.Id, opt => opt.DoNotValidate());
            cfg.CreateMap<MatchEntryDTO, MatchEntry>()
                .ForMember(u => u.Id, memberOptions => memberOptions.Ignore());
            cfg.CreateMap<Tournament, TournamentDTO>()
                    .ForSourceMember(u => u.TournamentEntries, opt => opt.DoNotValidate());
            cfg.CreateMap<Tournament, TournamentPlayersDTO>()
                .ForMember(tp => tp.Tournament, opt => { opt.MapFrom(t => t); })
                //.ForMember(tp => tp.Players, opt => { opt.Ignore(); });
                .ForMember(tp => tp.Players, opt => opt.MapFrom(t => t.TournamentEntries.Select(te => new PlayerDrawDTO()
                {
                    TournamentEntryId = te.Id,
                    PlayerId = te.Player.Id,
                    Name = te.Player.Name,
                    Surname = te.Player.Surname
                })));
        });

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
                    .ForSourceMember(u => u.TournamentEntries, opt => opt.DoNotValidate());
                cfg.CreateMap<TournamentDTO, Tournament>();
            });

            return config.CreateMapper();
        }

        public static MapperConfiguration GetPlayerDrawConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Player, PlayerDrawDTO>()
                    .ForMember(p => p.PlayerId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(p => p.TournamentEntryId, opt=> opt.Ignore());
            });

            return config;
        }

        public static IMapper GetPlayerMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Player, PlayerDTO>()
                    .ForSourceMember(u => u.TournamentEntries, opt => opt.DoNotValidate());
                cfg.CreateMap<PlayerDTO, Player>();
            });

            return config.CreateMapper();
        }

    }
}
