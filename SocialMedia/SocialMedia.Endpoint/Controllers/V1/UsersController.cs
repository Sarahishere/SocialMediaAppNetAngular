using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Persistence;
using SocialMedia.Persistence.Entities;

namespace SocialMedia.Endpoint.Controllers.V1;

[Authorize]
public class UsersController : BaseController
{
    public UsersController(DataContext context) : base(context)
    {
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
      
      return await _context.Users.Where( x => x.Status ==1).ToListAsync();

    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        return user;
    }


}
    

