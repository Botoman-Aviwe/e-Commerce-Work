using Log_In.Models;
using Microsoft.EntityFrameworkCore;

namespace Log_In.Data.Services
{
    public class ActorService : IActorService
    {
        private readonly ApplicationDbContext _context;
        public ActorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Actor actor)
        {
            _context.Actor.Add(actor);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actor.FirstOrDefaultAsync(n => n.Id == id);
            _context.Actor.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = _context.Actor.ToList();
            return result; ;
        }

        public async Task<Actor> GetById(int id)
        {
            var result = await _context.Actor.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public void SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }
    }
}
