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

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            CreateMap<GameCenters, GameCenterDto>()
                .ForMember(x => x.Latitude, dto => dto.MapFrom(prop => prop.Location.Y))
                .ForMember(x => x.Longitude, dto => dto.MapFrom(prop => prop.Location.X));
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            CreateMap<GameCenterCreationDto, GameCenters>()
                .ForMember(x => x.Location, x => x.MapFrom(dto =>
                    geometryFactory.CreatePoint(new Coordinate(dto.Longitude, dto.Latitude))));

            CreateMap<GameCreationDto, Game>()
                .ForMember(x => x.Poster, options => options.Ignore())
                .ForMember(x => x.GamesGenres, options => options.MapFrom(MapGamesGenres))
                .ForMember(x => x.GameCentersGame, option => option.MapFrom(MapGameCentersGames))
                .ForMember(x => x.GamesActors, option => option.MapFrom(MapGamesActors));
        }

        private List<GamesGenres> MapGamesGenres(GameCreationDto gameCreation, Game game)
        {
            var result = new List<GamesGenres>();

            if (gameCreation.GenreIds == null)
                return result;

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
                return result;

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
                return result;

            foreach (var actor in gameCreation.Actors)
            {
                result.Add(new GamesActors() { ActorId = actor.Id, Character = actor.Character });
            }

            return result;
        }
    }
}
