using SocialMedia.Persistence.Extentions;

namespace SocialMedia.Persistence.Entities;

public class AppUser : BaseEntity
{
    public string UserName { get; set; } = "";
    public string? FirstName { get; set; } 
    public string? LastName { get; set; }
    public byte[] PasswordHash { get; set; } = new byte[0];
    public byte[] PasswordSalt { get; set; } = new byte [0];
    public DateTime DateOfBirth { get; set; }
    public string? KnownAs { get; set; }
    public DateTime? LastActive { get; set; }
    public string? Gender { get; set; }
    public string? Introduction { get; set; }
    public string? LookingFor { get; set; }
    public string? Interests { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public List<Photo> Photos { get; set; } = new ();

    public int GetAge()
    {
        return DateOfBirth.CalculateAge();
    }
}