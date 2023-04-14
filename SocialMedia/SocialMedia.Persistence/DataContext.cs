using Microsoft.EntityFrameworkCore;
using SocialMedia.Persistence.Entities;

namespace SocialMedia.Persistence;

public class DataContext : DbContext
{
    public DbSet<AppUser>? Users { get; set;} 
    public DataContext(DbContextOptions options) : base(options)
    {
    }
}