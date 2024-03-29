﻿using AtaTennisApp.BL.DTO;
using AtaTennisApp.Data.Entities;
using AutoMapper;

namespace AtaTennisApp.BL.Helper
{
    /// <summary>
    /// Mapper helper for maping domain objects to DTO and vice versa. 
    /// documentation - https://docs.automapper.org/en/stable/Getting-started.html
    /// </summary>
    public static class MapperHelper
    {
        public static IMapper GetMapper()
        {
            return Configuration.CreateMapper();
        }

        public static MapperConfiguration Configuration { get; set; } = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Match, MatchDTO>()
                //.ForSourceMember(u => u.Id, opt => opt.DoNotValidate())
                .ReverseMap(); // reverse mapping - there is no need to create reverse map <MatchDTO, Match>
            cfg.CreateMap<MatchEntry, MatchEntryDTO>()
                //.ForSourceMember(u => u.Id, opt => opt.DoNotValidate())
                .ReverseMap();
            cfg.CreateMap<Tournament, TournamentDTO>()
                .ForSourceMember(u => u.TournamentEntries, opt => opt.DoNotValidate())
                .ReverseMap();
            cfg.CreateMap<Tournament, TournamentGraphDTO>()
                .ForMember(tp => tp.Tournament, opt => { opt.MapFrom(t => t); })
                .ForMember(tg => tg.Draw, opt => opt.Ignore());
                //.ForMember(tp => tp.StartingRound, opt => opt.MapFrom(t => t.Matches.Min(m => m.Round)))
                //.ForMember(tp => tp.Players, opt => { opt.Ignore(); });
                // not safe because when player or tournamentEntries are not included or taken from DB there will be null reference exception
                //.ForMember(tp => tp.Players, opt => opt.MapFrom(t => t.TournamentEntries.Select(te => new PlayerDrawDTO()
                // {
                //     TournamentEntryId = te.Id,
                //     PlayerId = te.Player.Id,
                //     Name = te.Player.Name,
                //     Surname = te.Player.Surname
                // })));
            //.ForMember(tp=> tp.Matches, opt => opt.MapFrom(t => t.Matches.Select(m => new MatchDTO { 
            //    Id = m.Id,
            //    Round = m.Round,

            //})));
            cfg.CreateMap<Score, ScoreDTO>().ReverseMap();
            cfg.CreateMap<TournamentEntry, TournamentEntryDTO>().ReverseMap();
        });

        public static IMapper GetUserMapper()
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<User, UserDTO>()
            //        .ForSourceMember(u => u.Id, opt => opt.DoNotValidate());
            //    cfg.CreateMap<UserDTO, User>()
            //        .ForMember(u => u.Id, memberOptions => memberOptions.Ignore());
            //});
            return Configuration.CreateMapper();
            //return config.CreateMapper();
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

        public static IMapper GetMatchMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Match, MatchDTO>();
                    //.ForMember(m => m.MatchEntries, )
            });

            return config.CreateMapper();
        }

        public static IMapper GetTournamentEntryMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TournamentEntry, TournamentEntryDTO>()
                    .ForMember(p => p.Id, opt => opt.MapFrom(src => src.Id));
                // TODO figure out automapper
                //.ForMember(p => p.TournamentEntryId, opt => opt.Ignore());
                cfg.CreateMap<TournamentEntryDTO, TournamentEntry>();

            });

            return config.CreateMapper();
        }
    }
}
