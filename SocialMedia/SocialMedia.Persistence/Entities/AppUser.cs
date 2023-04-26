using System;

namespace SocialMedia.Persistence.Entities;

public class AppUser : BaseEntity
{
    public string UserName { get; set; }
    public string? FirstName { get; set; } 
    public string? LastName { get; set; }
    public byte[] PasswordHash { get; set; } 
    public byte[] PasswordSalt { get; set; }
}