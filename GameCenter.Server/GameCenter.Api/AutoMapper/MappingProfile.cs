using AutoMapper;
using GameCenter.Business.DTOs.Genres;
using GameCenter.Models.Genre;

namespace GameCenter.Api.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GenreDto, Genre>().ReverseMap();
            CreateMap<GenreCreationDto, Genre>();
        }
    }
}
