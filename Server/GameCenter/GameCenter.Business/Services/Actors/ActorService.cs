using GameCenter.DataAccess.Repositories.Actors;
using GameCenter.Models.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.Services.Actors
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository repository;
        public ActorService(IActorRepository repository)
        {
            this.repository = repository;
        }

        public IQueryable<Actor> GetActorsAsQueryable()
        {
            return repository.GetActorsAsQueryable();
        }

        public async Task<Actor> GetActorByIdAsync(int id)
        {
            return await repository.GetActorByIdAsync(id);
        }

        public void AddActor(Actor actor)
        {
            repository.AddActor(actor);
        }

        public void DeleteActor(Actor actor)
        {
            repository.DeleteActor(actor);
        }


        public async Task SaveActorAsync()
        {
            await repository.SaveActorsAsync();
        }
    }
}
