
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Persistence;
using SocialMedia.Persistence.DTOs.Incoming;
using SocialMedia.Persistence.DTOs.Outgoing;
using SocialMedia.Persistence.Entities;
using SocialMedia.Persistence.Interfaces;

namespace SocialMedia.Endpoint.Controllers.V1
{
    public class AccountController : BaseController
    {
        private ITokenService _tokenService;

        public AccountController(DataContext context, ITokenService tokenService) : base(context)
        {
            _tokenService = tokenService;
        }

    [HttpPost("register")]
    public async Task<ActionResult<AuthReturnDto>> RegisterUser(RegisterDto registerDto)
    {
      
       if (await UserExists(registerDto.UserName))
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
       await _context.Users.AddAsync(user);
       await _context.SaveChangesAsync();

       return new AuthReturnDto
       {
          UserName = user.UserName,
          Token = _tokenService.CreateToken(user)
       };
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthReturnDto>> Login(LoginDto loginDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);
        
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

    private async Task<bool> UserExists(string userName)
    {
        return await _context.Users.AnyAsync(x => x.UserName == userName.ToLower());
    }

    }
    
}