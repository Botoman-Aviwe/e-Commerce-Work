using Log_In.Models;
namespace Log_In.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAll();
        Task<Actor> GetById(int id);
        void Add(Actor actor);
        void Delete(int id);
        void Update(int id, Actor newActor);
        void SaveChangesAsync();
    }
}
