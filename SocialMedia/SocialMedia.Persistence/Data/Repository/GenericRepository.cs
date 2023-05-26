

using Microsoft.EntityFrameworkCore;
using SocialMedia.Persistence.Interfaces;

namespace SocialMedia.Persistence.Data.Repository
{
    public class GenericRepository<T>: IGenericRepository<T> where T: class
    {
        private readonly DataContext _context;
        internal  DbSet<T> _dbSet;
        
        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<bool> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}