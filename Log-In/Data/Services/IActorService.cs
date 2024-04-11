using Log_In.Models;
namespace Log_In.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAll();
        Task<Actor> GetById(int id);
        //Test if this will work I have 2 Add but  they are different
       // void Add(Actor actor);
        //This is the testing Add
        Task<Actor> AddAsync(Actor actor);
        Task<Actor> DeleteAsync(int id);
        void Update(int id, Actor newActor);
        void SaveChangesAsync();
    }
}
