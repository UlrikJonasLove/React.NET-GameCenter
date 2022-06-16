using GameCenter.DataAccess.Data;
using GameCenter.Models.Actors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.DataAccess.Repositories.Actors
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext context;

        public ActorRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Actor> GetActorsAsQueryable()
        {
            return context.Actors.AsQueryable();
        }

        //public async Task<Actor> QueryByName()
        //{
        //    return await context.Actors.
        //}

        public async Task<Actor> GetActorByIdAsync(int id)
        {
            return await context.Actors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void AddActor(Actor actor)
        {
            context.Add(actor);
        }

        public void DeleteActor(Actor actor)
        {
            context.Remove(actor);
        }

        public async Task SaveActorsAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
