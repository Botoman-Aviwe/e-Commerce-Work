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
        public async Task<Actor> AddAsync(Actor actor)
        {
            _context.Actor.Add(actor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = _context.Actor.ToList();
            return result;
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

        public async void Update(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChanges();
            return newActor;
        }
    }
}
