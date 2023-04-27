
using SocialMedia.Persistence.Entities;

namespace SocialMedia.Persistence.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}