
using SocialMedia.Persistence.Entities;

namespace SocialMedia.Persistence.Interfaces
{
    public interface IUserRepository: IGenericRepository<AppUser>
    {
        
        Task<AppUser> GetByUsername(string username);
        
    }
}