
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Persistence.Data.DTOs.Incoming;
using SocialMedia.Persistence.Data.DTOs.Outgoing;
using SocialMedia.Persistence.Entities;
using SocialMedia.Persistence.Interfaces;

namespace SocialMedia.Endpoint.Controllers.V1
{
    public class AccountController : BaseController
    {
        private ITokenService _tokenService;

        public AccountController(
            IUnitOfWork unitOfWork, 
            ITokenService tokenService,
            IMapper mapper) : base(unitOfWork, mapper)
        {
            _tokenService = tokenService;
        }

    [HttpPost("register")]
    public async Task<ActionResult<AuthReturnDto>> RegisterUser(RegisterDto registerDto)
    {
        var existUser = await _unitOfWork.Users.GetByUsername(registerDto.UserName.ToLower());
      
       if (existUser != null)
       {
        return BadRequest("Username already exist");
       }
       using var hmac = new HMACSHA512(); //for adding salt
       var user = new AppUser
       {
        UserName = registerDto.UserName.ToLower(),
        FirstName = registerDto.FirstName,
        LastName = registerDto.LastName,
        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        PasswordSalt = hmac.Key
       };
       await _unitOfWork.Users.CreateAsync(user);
       await _unitOfWork.SaveAllAsync();

       return new AuthReturnDto
       {
          UserName = user.UserName,
          Token = _tokenService.CreateToken(user)
       };
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthReturnDto>> Login(LoginDto loginDto)
    {
        var user = await _unitOfWork.Users.GetByUsername(loginDto.UserName.ToLower());
        
        if (user == null) return BadRequest("User does not exist");
        
        using var hmac = new HMACSHA512(user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
        for ( int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
        }
        return new AuthReturnDto
        {
            UserName = user.UserName,
            Token = _tokenService.CreateToken(user)
        };
    }

    }
    
}