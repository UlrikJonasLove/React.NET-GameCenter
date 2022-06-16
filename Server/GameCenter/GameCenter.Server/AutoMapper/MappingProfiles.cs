using AutoMapper;
using GameCenter.Business.DTOs.Actors;
using GameCenter.Business.DTOs.GameCenters;
using GameCenter.Business.DTOs.Games;
using GameCenter.Business.DTOs.Genres;
using GameCenter.Models.Actors;
using GameCenter.Models.GameCenter;
using GameCenter.Models.Games;
using GameCenter.Models.Genres;
using NetTopologySuite.Geometries;
using System.Collections.Generic;

namespace GameCenter.Server.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(GeometryFactory geometryFactory)
        {
            CreateMap<GenreDto, Genre>().ReverseMap();
            CreateMap<GenreCreationDto, Genre>();

            CreateMap<ActorDto, Actor>().ReverseMap();
            CreateMap<ActorCreationDto, Actor>()
                .ForMember(x => x.Picture, option => option.Ignore());

            CreateMap<GameCenters, GameCenterDto>()
                .ForMember(x => x.Latitude, dto => dto.MapFrom(prop => prop.Location.Y))
                .ForMember(x => x.Longitude, dto => dto.MapFrom(prop => prop.Location.X));

            CreateMap<GameCenterCreationDto, GameCenters>()
                .ForMember(x => x.Location, x => x.MapFrom(dto =>
                    geometryFactory.CreatePoint(new Coordinate(dto.Longitude, dto.Latitude))));

            CreateMap<GameCreationDto, Game>()
                .ForMember(x => x.Poster, options => options.Ignore())
                .ForMember(x => x.GamesGenres, options => options.MapFrom(MapGamesGenres))
                .ForMember(x => x.GameCentersGame, option => option.MapFrom(MapGameCentersGames))
                .ForMember(x => x.GamesActors, option => option.MapFrom(MapGamesActors));

            CreateMap<Game, GameDto>()
                .ForMember(x => x.Genres, options => options.MapFrom(MapGamesGenres))
                .ForMember(x => x.GameCenters, options => options.MapFrom(MapGameCentersGames))
                .ForMember(x => x.Actors, options => options.MapFrom(MapGamesActors));
        }

        private List<ActorsGameDto> MapGamesActors(Game game, GameDto gameDto)
        {
            var result = new List<ActorsGameDto>();

            if (game.GamesActors != null)
            {
                foreach (var actors in game.GamesActors)
                {
                    result.Add(new ActorsGameDto()
                    {
                        Id = actors.ActorId,
                        Name = actors.Actor.Name,
                        Character = actors.Character,
                        Picture = actors.Actor.Picture,
                        Order = actors.Order
                    });
                }
            }

            return result;
        }

        private List<GameCenterDto> MapGameCentersGames(Game game, GameDto gameDto)
        {
            var result = new List<GameCenterDto>();

            if (game.GameCentersGame != null)
            {
                foreach (var gameCentersGames in game.GameCentersGame)
                {
                    result.Add(new GameCenterDto() { Id = gameCentersGames.GameCenterId, 
                        Name = gameCentersGames.GameCenter.Name,
                        Latitude = gameCentersGames.GameCenter.Location.Y,
                        Longitude = gameCentersGames.GameCenter.Location.X
                       });
                }
            }

            return result;
        }

        private List<GenreDto> MapGamesGenres(Game game, GameDto gameDto)
        {
            var result = new List<GenreDto>();

            if (game.GamesGenres != null)
            {
                foreach (var genre in game.GamesGenres)
                {
                    result.Add(new GenreDto() { Id = genre.GenreId, Name = genre.Genre.Name });
                }
            }

            return result;
        }

        private List<GamesGenres> MapGamesGenres(GameCreationDto gameCreation, Game game)
        {
            var result = new List<GamesGenres>();

            if (gameCreation.GenreIds == null)
            {
                return result;
            }
                

            foreach (var genreId in gameCreation.GenreIds)
            {
                result.Add(new GamesGenres() { GenreId = genreId});
            }

            return result;
        }

        private List<GameCentersGames> MapGameCentersGames(GameCreationDto gameCreation, Game game)
        {
            var result = new List<GameCentersGames>();

            if (gameCreation.GameCenterIds == null)
            {
                return result;
            }
                

            foreach (var gameCentersid in gameCreation.GameCenterIds)
            {
                result.Add(new GameCentersGames() { GameCenterId = gameCentersid });
            }

            return result;
        }

        private List<GamesActors> MapGamesActors(GameCreationDto gameCreation, Game game)
        {
            var result = new List<GamesActors>();

            if (gameCreation.Actors == null)
            {
                return result;
            }
                

            foreach (var actor in gameCreation.Actors)
            {
                result.Add(new GamesActors() { ActorId = actor.Id, Character = actor.Character });
            }

            return result;
        }
    }
}
