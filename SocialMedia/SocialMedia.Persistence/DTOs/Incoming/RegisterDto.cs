
using System.ComponentModel.DataAnnotations;


namespace SocialMedia.Persistence.DTOs.Incoming
{
    public class RegisterDto
    {
      [StringLength(12,MinimumLength = 2)]
      public string UserName { get; set; }
      [StringLength(12,MinimumLength = 4)]
      public string Password { get; set; } 
      public string? FirstName { get; set; }
      public string? LastName { get; set; }
    }
}