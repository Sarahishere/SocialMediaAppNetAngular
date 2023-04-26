
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Persistence;
using SocialMedia.Persistence.DTOs.Incoming;
using SocialMedia.Persistence.DTOs.Outgoing;
using SocialMedia.Persistence.Entities;

namespace SocialMedia.Endpoint.Controllers.V1
{
    public class AccountController : BaseController
    {
        public AccountController(DataContext context) : base(context)
        {
        }

    [HttpPost("register")]
    public async Task<ActionResult<UserReturnDto>> RegisterUser(RegisterDto registerDto)
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

       return new UserReturnDto
       {
          UserName = user.UserName,
          CreateDate = user.CreateDate,
          UpdateDate = user.UpdateDate,
          FirstName = user.FirstName,
          LastName = user.LastName
       };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserReturnDto>> Login(LoginDto loginDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);
        
        if (user == null) return BadRequest("User does not exist");
        
        using var hmac = new HMACSHA512(user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
        for ( int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
        }
        return new UserReturnDto
        {
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            CreateDate = user.CreateDate,
            UpdateDate = user.UpdateDate
        };
    }

    private async Task<bool> UserExists(string userName)
    {
        return await _context.Users.AnyAsync(x => x.UserName == userName.ToLower());
    }

    }
    
}