using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Persistence.Data.DTOs.Outgoing;
using SocialMedia.Persistence.Interfaces;

namespace SocialMedia.Endpoint.Controllers.V1;

[Authorize]
public class UsersController : BaseController
{
   

    public UsersController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork,mapper)
    {
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserReturnDto>>> GetUsers()
    {
      
      var userList = await _unitOfWork.Users.GetAllAsync();
      var userReturnDto = _mapper.Map<IEnumerable<UserReturnDto>>(userList);

       return Ok(userReturnDto);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<UserReturnDto>> GetUser(string username)
    {
        var user = await _unitOfWork.Users.GetByUsername(username);
        return _mapper.Map<UserReturnDto>(user);
    }


}
    

