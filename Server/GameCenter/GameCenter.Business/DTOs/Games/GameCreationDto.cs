using GameCenter.Business.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.DTOs.Games
{
    public class GameCreationDto
    {
        public string? Title { get; set; }
        public string? Trailer { get; set; }
        public bool? NewlyReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IFormFile? Poster { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<int>))]
        public List<int>? GenreIds { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<int>))]
        public List<int>? GameCenterIds { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<GameActorsCreationDto>))]
        public List<GameActorsCreationDto>? Actors { get; set; }
    }
}
