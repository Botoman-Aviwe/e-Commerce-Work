using Log_In.Models;

namespace Log_In.Data.Base
{
    public interface IEntityBaseRepository<in T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        //Test if this will work I have 2 Add but  they are different
        // void Add(Actor actor);
        //This is the testing Add
        Task<T> AddAsync(T Entity);
        Task<T> DeleteAsync(int id);
        Task Update(int id, T entity);
        void SaveChangesAsync();
    }
}
