using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Persistence;
using SocialMedia.Persistence.DTOs.Outgoing;
using SocialMedia.Persistence.Entities;

namespace SocialMedia.Endpoint.Controllers.V1;

[Authorize]
public class UsersController : BaseController
{
    public UsersController(DataContext context) : base(context)
    {
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserReturnDto>>> GetUsers()
    {
      
      var userList = await _context.Users.Where( x => x.Status ==1).ToListAsync();
      var userReturnDtoList = new List<UserReturnDto>();
      foreach ( var user in userList)
      {
        userReturnDtoList.Add(new UserReturnDto
        {
          UserName = user.UserName,
          FirstName = user.FirstName,
          LastName = user.LastName,
          CreateDate = user.CreateDate,
          UpdateDate = user.UpdateDate
        });
      }

       return userReturnDtoList;

    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<UserReturnDto>> GetUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        return new UserReturnDto
        {
          UserName = user.UserName,
          FirstName = user.FirstName,
          LastName = user.LastName,
          CreateDate = user.CreateDate,
          UpdateDate = user.UpdateDate
        };
    }


}
    

