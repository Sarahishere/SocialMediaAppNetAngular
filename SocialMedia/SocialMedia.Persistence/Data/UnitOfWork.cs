

using SocialMedia.Persistence.Data.Repository;
using SocialMedia.Persistence.Interfaces;

namespace SocialMedia.Persistence.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IUserRepository Users { get;}
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Users = new UserRepository(context);
            
        }
        
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}