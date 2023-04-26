
namespace SocialMedia.Persistence.DTOs.Outgoing
{
    public class UserReturnDto
    {
        public DateTime CreateDate {get; set;}
        public DateTime UpdateDate { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}