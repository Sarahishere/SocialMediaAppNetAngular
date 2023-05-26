using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Persistence;
using SocialMedia.Persistence.Data.DTOs.Outgoing;
using SocialMedia.Persistence.Entities;
using SocialMedia.Persistence.Interfaces;

namespace SocialMedia.Endpoint.Controllers.V1;

[Authorize]
public class UsersController : BaseController
{
    public UsersController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
    
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
      
      var userList = await _unitOfWork.Users.GetAllAsync();
     /* var userReturnDtoList = new List<UserReturnDto>();
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
      } */

       return Ok(userList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(Guid id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        return user;
    }


}
    

