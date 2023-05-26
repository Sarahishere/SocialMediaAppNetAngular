
namespace SocialMedia.Persistence.Data.DTOs.Outgoing
{
    public class UserReturnDto
    {
        public string UserName { get; set; } = "";
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int age { get; set; }
        public DateTime CreateDate {get; set;} 
        public DateTime UpdateDate { get; set; } 
        public string? KnownAs { get; set; }
        public DateTime? LastActive { get; set; }
        public string? Gender { get; set; }
        public string? Introduction { get; set; }
        public string? LookingFor { get; set; }
        public string? Interests { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public List<PhotoReturnDto> Photos { get; set; } 

    }
}