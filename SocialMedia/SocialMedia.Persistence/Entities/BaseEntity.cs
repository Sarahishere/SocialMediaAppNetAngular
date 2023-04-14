

namespace SocialMedia.Persistence.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Status { get; set; } = 1;
        public DateTime CreateDate {get; set;} = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        
    
    }
}