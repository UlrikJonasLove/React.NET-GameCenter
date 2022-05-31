using AutoMapper;
using GameCenter.Business.DTOs.Genres;
using GameCenter.Models.Genre;

namespace GameCenter.Server.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GenreDto, Genre>().ReverseMap();
            CreateMap<GenreCreationDto, Genre>();
        }
    }
}
