using Microsoft.EntityFrameworkCore;
using SocialMedia.Persistence.Entities;
using SocialMedia.Persistence.Interfaces;

namespace SocialMedia.Persistence.Data.Repository
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task<AppUser> GetByUsername(string username)
        {
            return await _dbSet
            .Include(p => p.Photos)
            .FirstOrDefaultAsync(x => x.UserName == username);
        }

        public override async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _dbSet
            .Where(x => x.Status == 1)
            .Include(p => p.Photos)
            .AsNoTracking().ToListAsync();
        }

      
    }
}