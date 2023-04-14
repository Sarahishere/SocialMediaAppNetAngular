using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Persistence;
using SocialMedia.Persistence.Entities;

namespace SocialMedia.Endpoint.Controllers.V1;

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

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        return user;
    }

    [HttpPost]
    public async Task<ActionResult<AppUser>> CreateUser(AppUser user)
    {
       await _context.Users.AddAsync(user);
       await _context.SaveChangesAsync();
        return Ok(user);
    }

}
    

