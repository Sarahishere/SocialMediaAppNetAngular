

namespace SocialMedia.Persistence.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        
        void UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(T entity);

        
    }
}