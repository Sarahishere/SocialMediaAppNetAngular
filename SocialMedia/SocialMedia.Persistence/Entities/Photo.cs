using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Persistence.Entities
{
    [Table("Photos")]
    public class Photo: BaseEntity
    {
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        //the following to properties make sure photo only correlate to user and when user got deleted, all photoes got deleted
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}