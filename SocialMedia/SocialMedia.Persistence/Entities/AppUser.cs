using System;

namespace SocialMedia.Persistence.Entities;

public class AppUser : BaseEntity
{
    public string? FirstName { get; set; } 
    public string? LastName { get; set; }
}