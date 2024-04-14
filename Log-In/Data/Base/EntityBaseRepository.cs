 
using Log_In.Models;
using Microsoft.EntityFrameworkCore;

namespace Log_In.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly ApplicationDbContext _context;
        public EntityBaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T Entity)
        {
           await _context.Set<T>().Add(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity=await _context.Set<T>().FirstDefaultAsync(n=>n.Id==id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }

        public async Task<IEnumerable<T>> GetAll()
        {
            var result = _context.Set<T>().ToList();
            return result;
        }

        public async Task<T> GetById(int id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public void SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry=_context.Entry<T>(entity);
            entityEntry.State=EntityState.Modified;
         await _context.SaveChangesAsync();

        }
    }

