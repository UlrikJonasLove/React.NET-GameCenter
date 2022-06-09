using GameCenter.Models.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.DataAccess.Repositories.Actors
{
    public interface IActorRepository
    {
        IQueryable<Actor> GetActorsAsQueryable();
        Task<Actor> GetActorByIdAsync(int id);
        void AddActor(Actor actor);
        void DeleteActor(Actor actor);
        Task SaveActorsAsync();
    }
}
