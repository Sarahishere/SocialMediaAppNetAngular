

namespace SocialMedia.Persistence.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task<bool> SaveAllAsync();
    }
}